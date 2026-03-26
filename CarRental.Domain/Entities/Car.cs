using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Enums;

namespace CarRental.Domain.Entities
{
    // Domain/Entities/Car.cs
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public string LicensePlate { get; set; } = default!;
        public string? Description { get; set; }
        public decimal PricePerDay { get; set; }
        public string City { get; set; } = default!;
        public CarStatus Status { get; set; } = CarStatus.Available;
        public CarCategory Category { get; set; }
        public int Seats { get; set; }
        public TransmissionType Transmission { get; set; }
        public FuelType FuelType { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int OwnerId { get; set; }
        public User Owner { get; set; } = default!;

        public ICollection<CarImage> Images { get; set; } = new List<CarImage>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
