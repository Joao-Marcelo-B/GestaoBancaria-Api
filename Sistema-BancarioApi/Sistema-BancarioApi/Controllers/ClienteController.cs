using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_BancarioApi.Data;
using Sistema_BancarioApi.Data.Dtos;
using Sistema_BancarioApi.Models;

namespace Sistema_BancarioApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private IMapper _mapper;
    private SistemaContext _context;

    public ClienteController(SistemaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadClienteDto> GetClientes
        ([FromQuery] int skip = 0,[FromQuery]int take = 50)
    {
        return _mapper.Map<List<ReadClienteDto>>
            (_context.Clientes.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetClientePorId(int id)
    {
        Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null) return NotFound();

        var clienteDto = _mapper.Map<ReadClienteDto>(cliente);

        return Ok(clienteDto);
    }
}
