using AutoMapper;
using GestaoBancariaApi.Data.Dtos;
using GestaoBancariaApi.Models;
using Microsoft.AspNetCore.Identity;

namespace GestaoBancariaApi.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}
