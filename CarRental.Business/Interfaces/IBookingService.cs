using CarRental.Business.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetMyBookingsAsync(int renterId);
        Task<IEnumerable<BookingDto>> GetBookingsByCarAsync(int carId, int ownerId);
        Task<BookingDto?> GetBookingByIdAsync(int id);
        Task<BookingDto> CreateBookingAsync(int renterId, CreateBookingDto dto);
        Task CancelBookingAsync(int bookingId, int userId);
    }
}
