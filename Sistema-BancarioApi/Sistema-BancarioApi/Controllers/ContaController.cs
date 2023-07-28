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

    [HttpPost]
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

    [HttpGet]
    public IEnumerable<ReadContaDto> GetContas()
    {
        return _mapper.Map<List<ReadContaDto>>(_context.Contas.ToList());
    }

    [HttpGet("{id}")]
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
    [HttpGet("extrato/{numConta}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadMovimentacoesDto> Extrato(string numConta)
    {
        var resultado = _mapper.Map<List<ReadMovimentacoesDto>>(_context.Movimentacoes
            .Where(mov => mov.DestinoNumConta == numConta || mov.OrigemNumConta == numConta).ToList());

        foreach(var item in resultado)
        {
            if(item.OrigemNumConta == numConta)
            {
                item.ValorMovimentado *= -1;
            }
        }

        return resultado;
    }
}
