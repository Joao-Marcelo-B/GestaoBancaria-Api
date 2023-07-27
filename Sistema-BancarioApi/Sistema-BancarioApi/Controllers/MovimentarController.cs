using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_BancarioApi.Data;
using Sistema_BancarioApi.Data.Dtos;
using Sistema_BancarioApi.Models;

namespace Sistema_BancarioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovimentarController : ControllerBase
{
    private IMapper _mapper;
    private SistemaContext _context;

    public MovimentarController(SistemaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Transferir([FromBody]CreateMovimentacoesDto dto)
    {
        Movimentacoes movimentacoes = _mapper.Map<Movimentacoes>(dto);

        _context.Add(movimentacoes);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovimentacaoPorId), new { id = movimentacoes.Id }, movimentacoes);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovimentacaoPorId(int id)
    {
        Movimentacoes mov = _context.Movimentacoes.FirstOrDefault(mov => mov.Id == id);

        if (mov == null) return NotFound();

        var movDto = _mapper.Map<ReadMovimentacoesDto>(mov);

        return Ok(movDto);
    }
}
