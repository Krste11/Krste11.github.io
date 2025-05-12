using TaxiManager9000.DataAccess;
using TaxiManager9000.Services;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Modals;

namespace TaxiManager9000
{
    class Program
    {
        // Make the 'database' public and static so it's accessible globally
        //public static Database database = new Database();
        public static Database database = new Database();
        static void Main(string[] args)
        {
            Console.WriteLine("dsds");
            var carService = new CarService();
            var driverService = new DriverService();
            var userService = new UserService();

            // Example usage:
            carService.AddCar(new Car { Id = 1, Model = "Toyota", LicensePlate = "ABC123" });
            driverService.AddDriver(new Driver { Id = 1, FirstName = "John", LastName = "Doe" });
            userService.CreateUser(new User { Id = 1, UserName = "admin", Password = "password123", Role = Role.Admin });

            // Implement menu and user interaction logic here...
        }
    }
}
