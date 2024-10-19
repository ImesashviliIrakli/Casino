using AutoMapper;
using Users.Application.Models.Wallet;
using Users.Domain.Entities;

namespace Users.Application.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Wallet, WalletDto>().ReverseMap();
    }
}
