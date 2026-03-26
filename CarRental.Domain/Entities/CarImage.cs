using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    // Domain/Entities/CarImage.cs
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = default!;
        public bool IsPrimary { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CarId { get; set; }
    }
}
