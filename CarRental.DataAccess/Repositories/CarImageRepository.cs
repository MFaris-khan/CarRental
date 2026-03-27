using CarRental.DataAccess.Context;
using CarRental.DataAccess.Interfaces;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.DataAccess.Repositories;

public class CarImageRepository : ICarImageRepository
{
    private readonly AppDbContext _context;

    public CarImageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CarImage>> GetByCarIdAsync(int carId)
    {
        return await _context.CarImages
            .Where(i => i.CarId == carId)
            .ToListAsync();
    }

    public async Task AddAsync(CarImage image)
    {
        await _context.CarImages.AddAsync(image);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var image = await _context.CarImages.FindAsync(id);
        if (image != null)
        {
            _context.CarImages.Remove(image);
            await _context.SaveChangesAsync();
        }
    }
}