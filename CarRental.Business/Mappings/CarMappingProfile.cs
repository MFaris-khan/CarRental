using AutoMapper;
using CarRental.Business.DTOs.Car;
using CarRental.Domain.Entities;

namespace CarRental.Business.Mappings;

public class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<CarImage, CarImageDto>();

        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.OwnerName,
                opt => opt.MapFrom(src => src.Owner.FirstName + " " + src.Owner.LastName))
            .ForMember(dest => dest.Images,
                opt => opt.MapFrom(src => src.Images));
    }
}