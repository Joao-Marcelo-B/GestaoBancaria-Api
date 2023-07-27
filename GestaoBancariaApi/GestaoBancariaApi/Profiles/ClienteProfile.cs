using AutoMapper;
using GestaoBancaria.Models;
using GestaoBancariaApi.Data.Dtos;

namespace GestaoBancariaApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateUsuarioDto, Cliente>();
    }
}
