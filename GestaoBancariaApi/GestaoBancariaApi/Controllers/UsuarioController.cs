using AutoMapper;
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
    public UsuarioController(UsuarioService user)
    {
        _userService = user;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarCliente([FromBody] CreateUsuarioDto dto)
    {
        await _userService.Cadastra(dto);
        return Ok("Usuário cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
    {
        await _userService.Login(dto);

        return Ok("Usuário autenticado com sucesso!");
    }
}
