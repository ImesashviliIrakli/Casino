using AutoMapper;
using Games.Application.Models;
using Games.Domain.Entities;

namespace Games.Application.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GameProvider, GameProviderDto>().ReverseMap();
        CreateMap<Game, GameDto>().ReverseMap();
    }
}
