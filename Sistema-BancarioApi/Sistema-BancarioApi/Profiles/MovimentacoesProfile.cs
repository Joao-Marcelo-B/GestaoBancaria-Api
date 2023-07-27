using AutoMapper;
using Sistema_BancarioApi.Data.Dtos;
using Sistema_BancarioApi.Models;

namespace Sistema_BancarioApi.Profiles;

public class MovimentacoesProfile : Profile
{
    public MovimentacoesProfile()
    {
        CreateMap<CreateMovimentacoesDto, Movimentacoes>();
    }
}
