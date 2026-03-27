using CarRental.Business.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCarsAsync();
        Task<IEnumerable<CarDto>> GetCarsByOwnerAsync(int ownerId);
        Task<CarDto?> GetCarByIdAsync(int id);
        Task<CarDto> CreateCarAsync(int ownerId, CreateCarDto dto);
        Task UpdateCarAsync(int carId, int ownerId, UpdateCarDto dto);
        Task DeleteCarAsync(int carId, int ownerId);
    }
}
