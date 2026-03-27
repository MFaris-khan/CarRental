using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetByRenterIdAsync(int renterId);
        Task<IEnumerable<Booking>> GetByCarIdAsync(int carId);
        Task<Booking?> GetByIdAsync(int id);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
    }
}
