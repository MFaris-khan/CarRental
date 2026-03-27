using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Interfaces
{
    public interface ICarImageRepository
    {
        Task<IEnumerable<CarImage>> GetByCarIdAsync(int carId);
        Task AddAsync(CarImage image);
        Task DeleteAsync(int id);
    }
}
