using AutoMapper;
using Banking.Application.Models;
using Banking.Domain.Entities;

namespace Banking.Application.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PaymentSystem, PaymentSystemDto>().ReverseMap();
    }
}
