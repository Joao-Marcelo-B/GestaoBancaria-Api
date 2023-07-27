using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_BancarioApi.Data;
using Sistema_BancarioApi.Data.Dtos;

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
    public IEnumerable<ReadClienteDto> GetClientes()
    {
        return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.ToList());
    }
}
