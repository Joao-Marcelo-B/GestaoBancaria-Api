using AutoMapper;
using GestaoBancariaApi.Data;
using GestaoBancariaApi.Data.Dtos;
using GestaoBancariaApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestaoBancariaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IMapper _mapper;
    private UsuarioDbContext _context;
    private UserManager<Usuario> _userManager;
    public UsuarioController(IMapper mapper, UsuarioDbContext context = null, UserManager<Usuario> userManager = null)
    {
        _mapper = mapper;
        _context = context;
        _userManager = userManager;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarCliente([FromBody] CreateUsuarioDto dto)
    {
        var cliente = _mapper.Map<Usuario>(dto);
        IdentityResult resultado = await _userManager.CreateAsync(cliente, dto.Password);

        if(resultado.Succeeded)
        {
            return Ok("Cliente cadastrado com sucesso!");
        }
        throw new ApplicationException("Falha ao cadastrar cliente!");
    }
}
