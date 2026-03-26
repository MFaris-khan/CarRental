using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Configurations
{
    // DataAccess/Configurations/BookingConfiguration.cs
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.TotalPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(b => b.Status).HasConversion<string>();
            builder.Property(b => b.CancellationReason).HasMaxLength(500);
        }
    }
}
