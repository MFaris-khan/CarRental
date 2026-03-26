using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.DTOs.Car
{
    public class UpdateCarDto
    {
        public string? Description { get; set; }
        public decimal? PricePerDay { get; set; }
        public string? City { get; set; }
        public CarStatus? Status { get; set; }
        public int? Seats { get; set; }
        public TransmissionType? Transmission { get; set; }
        public FuelType? FuelType { get; set; }
    }
}
