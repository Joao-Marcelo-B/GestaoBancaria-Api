using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_BancarioApi.Data;
using Sistema_BancarioApi.Data.Dtos;
using Sistema_BancarioApi.Models;

namespace Sistema_BancarioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaController : ControllerBase
{
    private IMapper _mapper;
    private SistemaContext _context;

    public ContaController(SistemaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     Gera uma conta aleatória para um cliente previamente cadastrado no sistema
    /// </summary>
    /// <param name="dto">Parâmetro a ser passado pelo corpo da requisição contendo o ClienteId</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a criação seja realizada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult GerarConta([FromBody] CreateContaDto dto)
    {
        dto.GerarNumeroConta();
        Console.WriteLine(dto.DigitoVerificador);
        Console.WriteLine(dto.NumeroConta);

        var conta = _mapper.Map<Conta>(dto);

        _context.Add(conta);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetContaPorId), new {id = conta.Id} ,conta);
    }

    /// <summary>
    ///     Recupera as contas de acordo com os parâmetros skip e take
    /// </summary>
    /// <param name="skip">Pula a quantidade de objetos informado</param>
    /// <param name="take">Pega a quantidade de objetos informado</param>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso seja realizado com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadContaDto> GetContas
        ([FromQuery]int skip = 0, [FromQuery]int take = 50)
    {
        return _mapper.Map<List<ReadContaDto>>
            (_context.Contas.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    ///     Recupera uma conta pelo Id
    /// </summary>
    /// <param name="id">ID a ser passado para busca</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja realizada com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetContaPorId(int id)
    {
        Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);

        if (conta == null) return NotFound();

        var contaDto = _mapper.Map<ReadContaDto>(conta);

        return Ok(contaDto);
    }


    /// <summary>
    ///     Recupera o saldo da conta desejada
    /// </summary>
    /// <param name="dto">Parâmetro a ser passado pelo corpo da requisição contendo o número da conta e o digito verificador</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja realizada com sucesso</response>
    [HttpGet("saldo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetSaldo([FromBody]GetSaldoDto dto)
    {
        Conta conta = _context.Contas.FirstOrDefault
            (conta => conta.NumeroConta == dto.NumeroConta &&
            conta.DigitoVerificador == dto.DigitoVerificador);

        if (conta == null) return NotFound();

        var contaDto = _mapper.Map<ReadSaldoDto>(conta);

        return Ok(contaDto);
    }

    /// <summary>
    ///     Método para transferir valores entre contas
    /// </summary>
    /// <param name="dto">Esse parâmetro contém informações que relacionam as duas contas para transferências</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a atualização seja realizada com sucesso</response>
    [HttpPut("transferir")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Transferir([FromBody] CreateMovimentacoesDto dto)
    {
        Conta contaOrigem = _context.Contas.FirstOrDefault
            (conta => conta.NumeroConta == dto.OrigemNumConta);

        Conta contaDestino = _context.Contas.FirstOrDefault(conta => conta.NumeroConta == dto.DestinoNumConta);

        if ((contaOrigem.Saldo - dto.ValorMovimentado) >= 0)
        {
            contaOrigem.Saldo -= dto.ValorMovimentado;
            contaDestino.Saldo += dto.ValorMovimentado;

            var updateContaOrigem = _mapper.Map<Conta>(contaOrigem);
            var updateContaDestino = _mapper.Map<Conta>(contaDestino);
            Movimentacoes mov = _mapper.Map<Movimentacoes>(dto);
            _context.Add(mov);
            _context.SaveChanges();

            var readMov = _mapper.Map<ReadMovimentacoesDto>(mov);

            return Ok(readMov);
        }
        return NotFound();
    }

    /// <summary>
    ///     Gera o Extrato da conta pelo número da conta que é passado como parâmetro
    /// </summary>
    /// <param name="numConta">Parâmetro para busca do extrato da conta desejada</param>
    /// <returns>IEnurable</returns>
    /// <response code="200">Caso a busca seja realizada com sucesso</response>
    [HttpGet("extrato")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadMovimentacoesDto> Extrato([FromBody]GetExtratoDto dto)
    {
        var resultado = _mapper.Map<List<ReadMovimentacoesDto>>(_context.Movimentacoes
            .Where(mov => mov.DestinoNumConta == dto.NumeroConta || mov.OrigemNumConta == dto.NumeroConta).ToList());

        foreach(var item in resultado)
        {
            if(item.OrigemNumConta == dto.NumeroConta)
            {
                item.ValorMovimentado *= -1;
            }
        }

        return resultado;
    }
}
