using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Modals;

namespace TaxiManager9000.Services
{
    public class CarService
    {
        // Add a new car
        public void AddCar(Car car)
        {
            Program.database.Cars.Add(car); // Directly accessing the public static 'database' instance
        }

    // List all cars
    public List<Car> ListAllCars()
        {
            return Program.database.Cars; // Accessing the public static 'database' instance
        }

        // Check the license expiry of a car
        public string CheckLicenseExpiry(Car car)
        {
            var expiryDate = car.LicensePlateExpiryDate;
            var daysLeft = (expiryDate - DateTime.Now).Days;

            if (daysLeft < 0)
                return "Red"; // Expired
            else if (daysLeft <= 90)
                return "Yellow"; // 3 months to expiry
            else
                return "Green"; // Valid
        }

        // List operational vehicles (not assigned to a driver for a shift)
        public List<Car> ListOperationalVehicles()
        {
            return Program.database.Cars.Where(c => c.AssignedDrivers.All(d => d.Shift == Shift.Morning || d.Shift == Shift.Afternoon || d.Shift == Shift.Evening)).ToList();
        }
    }
}
