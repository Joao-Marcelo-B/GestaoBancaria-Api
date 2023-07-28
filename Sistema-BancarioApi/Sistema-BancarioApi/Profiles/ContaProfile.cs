using AutoMapper;
using Sistema_BancarioApi.Data.Dtos;
using Sistema_BancarioApi.Managers;
using Sistema_BancarioApi.Models;

namespace Sistema_BancarioApi.Profiles;

public class ContaProfile : Profile
{
    public ContaProfile()
    {
        CreateMap<CreateContaDto, Conta>();
        CreateMap<Conta, ReadContaDto>()
            .ForMember(contaDto => contaDto.Cliente,
                opt => opt.MapFrom(conta => conta.Cliente));
        CreateMap<Conta, ReadSaldoDto>();
        CreateMap<UpdateTransfereDto, Conta>();
    }
}
