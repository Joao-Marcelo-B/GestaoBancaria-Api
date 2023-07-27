using AutoMapper;
using Data;
using GestaoBancaria.Models;
using GestaoBancariaApi.Data;
using GestaoBancariaApi.Data.Dtos;
using GestaoBancariaApi.Models;
using GestaoBancariaApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestaoBancariaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private UsuarioService _userService;
    private IMapper _mapper;
    private ClienteContext _context;
    public UsuarioController(UsuarioService user, IMapper mapper, ClienteContext context)
    {
        _userService = user;
        _mapper = mapper;
        _context = context;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarCliente
        ([FromBody] CreateUsuarioDto dto)
    {
        Cliente cliente = _mapper.Map<Cliente>(dto);

        _context.Add(cliente);

        await _userService.Cadastra(dto);

        _context.SaveChanges();

        return Ok("Usuário cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
    {
        await _userService.Login(dto);

        return Ok("Usuário autenticado com sucesso!");
    }
}
