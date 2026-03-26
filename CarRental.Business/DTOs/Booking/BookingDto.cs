using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.DTOs.Booking
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Who rented
        public int RenterId { get; set; }
        public string RenterName { get; set; } = default!;

        // Which car
        public int CarId { get; set; }
        public string CarTitle { get; set; } = default!;   // "2022 Toyota Corolla" Make, Model, Year
        public string OwnerName { get; set; } = default!;
    }
}
