using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Modals
{
    public class Driver : BaseEntity
    {
        public Driver()
        {
            
        }
        public Driver(string firstname, string lastname, Shift shift, Car car, string license, DateTime exipiryDate)
        {
            FirstName = firstname;
            LastName = lastname;
            Shift = shift;
            Car = car;
            License = license;
            LicenseExpiryDate = exipiryDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Shift Shift { get; set; }
        public Car Car { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public string FullName => FirstName + " " + LastName;

        public override string Print()
        {
            string model = Car == null ? "no car assigned." : Car.Model;
            return $"{Id}) {FullName} driving in the {Shift} shift with a {model}";
        }
        public ExpiryStatus IsLicenseExpired()
        {
            if (DateTime.Today >= LicenseExpiryDate) return ExpiryStatus.Expired;
            else if (DateTime.Today.AddMonths(3) >= LicenseExpiryDate) return ExpiryStatus.Warning;
            else return ExpiryStatus.Valid;
        }
    }
}
