using CarRental.DataAccess.Context;
using CarRental.DataAccess.Interfaces;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DataAccess.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetByRenterIdAsync(int renterId)
    {
        return await _context.Bookings
            .Include(b => b.Car)
                .ThenInclude(c => c.Owner)
            .Include(b => b.Renter)
            .Where(b => b.RenterId == renterId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetByCarIdAsync(int carId)
    {
        return await _context.Bookings
            .Include(b => b.Renter)
            .Where(b => b.CarId == carId)
            .ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await _context.Bookings
            .Include(b => b.Car)
                .ThenInclude(c => c.Owner)
            .Include(b => b.Renter)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }
}