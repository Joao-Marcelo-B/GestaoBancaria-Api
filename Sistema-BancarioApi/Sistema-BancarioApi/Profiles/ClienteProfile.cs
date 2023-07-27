using AutoMapper;
using Sistema_BancarioApi.Data.Dtos;
using Sistema_BancarioApi.Models;

namespace Sistema_BancarioApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Cliente, ReadClienteDto>();
    }
}
