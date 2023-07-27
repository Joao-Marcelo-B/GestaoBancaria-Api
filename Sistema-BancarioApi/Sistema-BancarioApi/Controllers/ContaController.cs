using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_BancarioApi.Data;
using Sistema_BancarioApi.Data.Dtos;
using Sistema_BancarioApi.Managers;
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

    [HttpGet("saldo")]
    public IActionResult GetSaldo([FromBody]GetSaldoDto dto)
    {
        Conta conta = _context.Contas.FirstOrDefault
            (conta => conta.NumeroConta == dto.NumeroConta &&
            conta.DigitoVerificador == dto.DigitoVerificador);

        if (conta == null) return NotFound();

        var contaDto = _mapper.Map<ReadSaldoDto>(conta);

        return Ok(contaDto);
    }

    //[HttpPost]
    //public IActionResult Transferir([FromBody]TranferenciaDto dto)
    //{

    //}
}
