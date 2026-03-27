using AutoMapper;
using CarRental.Business.DTOs.Auth;
using CarRental.Domain.Entities;

namespace CarRental.Business.Mappings;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<User, AuthResponseDto>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.Token,
                opt => opt.Ignore());         // Token is set manually in AuthService
    }
}