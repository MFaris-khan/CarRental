using AutoMapper;
using CarRental.Business.DTOs.Booking;
using CarRental.Domain.Entities;

namespace CarRental.Business.Mappings;

public class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.RenterName,
                opt => opt.MapFrom(src => src.Renter.FirstName + " " + src.Renter.LastName))
            .ForMember(dest => dest.CarTitle,
                opt => opt.MapFrom(src => src.Car.Year + " " + src.Car.Make + " " + src.Car.Model))
            .ForMember(dest => dest.OwnerName,
                opt => opt.MapFrom(src => src.Car.Owner.FirstName + " " + src.Car.Owner.LastName));
    }
}