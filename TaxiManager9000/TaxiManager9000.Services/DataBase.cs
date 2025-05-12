using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Modals;

namespace TaxiManager9000.DataAccess
{
    public static class Database
    {
        // Static lists simulating tables
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                UserName = "admin",
                Password = "admin123", // (In real app, you'd hash this!)
                Role = Role.Admin
            },
            new User
            {
                Id = 2,
                UserName = "manager",
                Password = "manager1",
                Role = Role.Manager
            },
            new User
            {
                Id = 3,
                UserName = "maintenance",
                Password = "maint1",
                Role = Role.Maintence
            }
        };

        public static List<Car> Cars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Model = "Toyota Prius",
                LicensePlate = "SK-1234-AB",
                LicensePlateExpiryDate = DateTime.Today.AddMonths(6),
                DriverAssigned = new List<Driver>()
            },
            new Car
            {
                Id = 2,
                Model = "Volkswagen Passat",
                LicensePlate = "SK-5678-CD",
                LicensePlateExpiryDate = DateTime.Today.AddMonths(2),
                DriverAssigned = new List<Driver>()
            },
            new Car
            {
                Id = 3,
                Model = "Skoda Octavia",
                LicensePlate = "SK-9876-EF",
                LicensePlateExpiryDate = DateTime.Today.AddMonths(-1), // Expired plate
                DriverAssigned = new List<Driver>()
            }
        };

        public static List<Driver> Drivers = new List<Driver>
        {
            new Driver
            {
                Id = 1,
                FirstName = "Marko",
                LastName = "Markovski",
                Shift = Shift.Morning,
                Car = Cars[0], // Assigned to Toyota Prius
                License = "MKD-112233",
                LicenseExpiryDate = DateTime.Today.AddMonths(4)
            },
            new Driver
            {
                Id = 2,
                FirstName = "Ivana",
                LastName = "Ivanovska",
                Shift = Shift.NoShift, // Not assigned yet
                Car = null,
                License = "MKD-445566",
                LicenseExpiryDate = DateTime.Today.AddMonths(1) // Almost expiring
            },
            new Driver
            {
                Id = 3,
                FirstName = "Stefan",
                LastName = "Stefanovski",
                Shift = Shift.Afternoon,
                Car = Cars[1], // Assigned to VW Passat
                License = "MKD-778899",
                LicenseExpiryDate = DateTime.Today.AddMonths(-2) // Expired license
            }
        };

        // Constructor to connect drivers to cars
        static Database()
        {
            Cars[0].DriverAssigned.Add(Drivers[0]); // Marko -> Toyota Prius
            Cars[1].DriverAssigned.Add(Drivers[2]); // Stefan -> VW Passat
        }
    }
}
