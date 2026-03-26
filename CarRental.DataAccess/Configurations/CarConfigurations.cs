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
    // DataAccess/Configurations/CarConfiguration.cs
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Make).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Model).HasMaxLength(100).IsRequired();
            builder.Property(c => c.LicensePlate).HasMaxLength(20).IsRequired();
            builder.Property(c => c.City).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.PricePerDay).HasPrecision(18, 2).IsRequired();
            builder.Property(c => c.Status).HasConversion<string>();
            builder.Property(c => c.Category).HasConversion<string>();
            builder.Property(c => c.Transmission).HasConversion<string>();
            builder.Property(c => c.FuelType).HasConversion<string>();

            builder.HasIndex(c => c.LicensePlate).IsUnique();

            builder.HasQueryFilter(c => c.IsActive);

            builder.HasMany(c => c.Images)
                   .WithOne()
                   .HasForeignKey(i => i.CarId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Bookings)
                   .WithOne(b => b.Car)
                   .HasForeignKey(b => b.CarId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
