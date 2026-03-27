using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.DTOs.Car
{
    public class CreateCarDto
    {
        public string Make { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public string LicensePlate { get; set; } = default!;
        public string? Description { get; set; }
        public decimal PricePerDay { get; set; }
        public string City { get; set; } = default!;
        public CarCategory Category { get; set; }
        public int Seats { get; set; }
        public TransmissionType Transmission { get; set; }
        public FuelType FuelType { get; set; }
        public List<CarImageDto> Images { get; set; } = new();
    }
}
