using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Enums
{
    // Added all enums to a single file. Can be split into separate files if needed for better organization.

    // Domain/Enums/UserRole.cs
    public enum UserRole { User, Admin }

    // Domain/Enums/CarStatus.cs
    public enum CarStatus { Available, Booked, UnderMaintenance }

    // Domain/Enums/CarCategory.cs
    public enum CarCategory { Sedan, SUV, Hatchback, Coupe, Van, Truck }

    // Domain/Enums/TransmissionType.cs
    public enum TransmissionType { Automatic, Manual }

    // Domain/Enums/FuelType.cs
    public enum FuelType { Petrol, Diesel, Electric, Hybrid }

    // Domain/Enums/BookingStatus.cs
    public enum BookingStatus { Pending, Confirmed, Ongoing, Completed, Cancelled }

}
