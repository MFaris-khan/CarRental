// Business/Services/CarService.cs
using AutoMapper;
using CarRental.Business.DTOs.Car;
using CarRental.Business.Interfaces;
using CarRental.DataAccess.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;

namespace CarRental.Business.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
    {
        var cars = await _carRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }

    public async Task<IEnumerable<CarDto>> GetCarsByOwnerAsync(int ownerId)
    {
        var cars = await _carRepository.GetByOwnerIdAsync(ownerId);
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }

    public async Task<CarDto?> GetCarByIdAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);
        return car == null ? null : _mapper.Map<CarDto>(car);
    }

    public async Task<CarDto> CreateCarAsync(int ownerId, CreateCarDto dto)
    {
        var car = new Car
        {
            Make = dto.Make,
            Model = dto.Model,
            Year = dto.Year,
            LicensePlate = dto.LicensePlate,
            Description = dto.Description,
            PricePerDay = dto.PricePerDay,
            City = dto.City,
            Category = dto.Category,
            Seats = dto.Seats,
            Transmission = dto.Transmission,
            FuelType = dto.FuelType,
            OwnerId = ownerId,
            Status = CarStatus.Available,
            CreatedAt = DateTime.UtcNow,

            Images = dto.Images.Select(i => new CarImage
            {
                ImageUrl = i.ImageUrl,
                IsPrimary = i.IsPrimary
            }).ToList()
        };

        await _carRepository.AddAsync(car);
        var created = await _carRepository.GetByIdAsync(car.Id);
        return _mapper.Map<CarDto>(created!);
    }

    public async Task UpdateCarAsync(int carId, int ownerId, UpdateCarDto dto)
{
    var car = await _carRepository.GetByIdAsync(carId);

    if (car == null)
        throw new KeyNotFoundException("Car not found.");

    if (car.OwnerId != ownerId)
        throw new UnauthorizedAccessException("You are not the owner of this car.");

    // Block ALL updates if car is Booked or Ongoing
    if (car.Status == CarStatus.Booked || car.Status == CarStatus.Ongoing)
        throw new InvalidOperationException("Car cannot be updated while it is booked or ongoing.");

    // Only listing details can ever be changed — never Make, Model, Year, LicensePlate
    if (dto.Description != null) car.Description = dto.Description;
    if (dto.PricePerDay.HasValue) car.PricePerDay = dto.PricePerDay.Value;
    if (dto.City != null) car.City = dto.City;
    if (dto.Seats.HasValue) car.Seats = dto.Seats.Value;
    if (dto.Status.HasValue) car.Status = dto.Status.Value;
    if (dto.Transmission.HasValue) car.Transmission = dto.Transmission.Value;
    if (dto.FuelType.HasValue) car.FuelType = dto.FuelType.Value;

    await _carRepository.UpdateAsync(car);
}

    public async Task DeleteCarAsync(int carId, int ownerId)
    {
        var car = await _carRepository.GetByIdAsync(carId);

        if (car == null)
            throw new KeyNotFoundException("Car not found.");

        if (car.OwnerId != ownerId)
            throw new UnauthorizedAccessException("You are not the owner of this car.");

        if (car.Status == CarStatus.Booked || car.Status == CarStatus.Ongoing)
            throw new InvalidOperationException("Car cannot be deleted while it is booked or ongoing.");

        await _carRepository.DeleteAsync(carId);
    }
}