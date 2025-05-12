using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Modals
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpiryDate { get; set; }
        public List<Driver> DriverAssigned { get; set; }

        public override string Print()
        {
            int assignedPercent = DriverAssigned.Count == 0 ? 0 : 100 / 3 * DriverAssigned.Count + 1;
            return $"{Id}) {Model} with license plate {LicensePlate} and utilized {assignedPercent}%";
        }
        public ExpiryStatus IsLicensePlateExpired()
        {
            if (DateTime.Today >= LicensePlateExpiryDate) return ExpiryStatus.Expired;
            else if (DateTime.Today.AddMonths(3) >= LicensePlateExpiryDate) return ExpiryStatus.Warning;
            else return ExpiryStatus.Valid;
        }
    }
}
