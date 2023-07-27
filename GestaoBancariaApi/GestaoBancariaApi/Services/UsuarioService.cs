using AutoMapper;
using GestaoBancariaApi.Data;
using GestaoBancariaApi.Data.Dtos;
using GestaoBancariaApi.Models;
using Microsoft.AspNetCore.Identity;

namespace GestaoBancariaApi.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private SignInManager<Usuario> _signInManager;
    private UserManager<Usuario> _userManager;
    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task Cadastra(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

        if(!result.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário");
        }
    }

    public async Task Login(LoginUsuarioDto dto)
    {
        var resultado = await _signInManager
            .PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if(!resultado.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado"); 
        }
    }
}
