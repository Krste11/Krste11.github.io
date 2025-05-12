using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Modals;

namespace TaxiManager9000.Services
{
    public class DriverService
    {
        // Add a new driver
        public void AddDriver(Driver driver)
        {
            Program.database.Drivers.Add(driver); // Directly accessing the public static 'database' instance
        }

        // List all drivers
        public List<Driver> ListAllDrivers()
        {
            return Program.database.Drivers; // Accessing the public static 'database' instance
        }

        // Check driver's license expiry
        public string CheckDriverLicenseExpiry(Driver driver)
        {
            var expiryDate = driver.LicenseExpiryDate;
            var daysLeft = (expiryDate - DateTime.Now).Days;

            if (daysLeft < 0)
                return "Red"; // Expired
            else if (daysLeft <= 90)
                return "Yellow"; // 3 months to expiry
            else
                return "Green"; // Valid
        }

        // Assign a driver to a car for a shift
        public bool AssignDriverToCar(Driver driver, Car car, Shift shift)
        {
            if (car.AssignedDrivers.Any(d => d.Shift == shift)) return false; // Car already assigned to this shift

            driver.Shift = shift;
            car.AssignedDrivers.Add(driver);
            return true;
        }

        // Unassign a driver from a car
        public void UnassignDriverFromCar(Driver driver, Car car)
        {
            car.AssignedDrivers.Remove(driver);
        }
    }
}
