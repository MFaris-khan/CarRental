using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.DTOs.Car
{
    public class CarImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = default!;
        public bool IsPrimary { get; set; }
    }
}
