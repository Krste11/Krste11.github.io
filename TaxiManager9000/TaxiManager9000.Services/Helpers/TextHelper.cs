using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Services.Helpers
{
    public static class TextHelper
    {
        // Format expiry status text
        public static string GetExpiryStatusText(string status)
        {
            switch (status)
            {
                case "Red":
                    return "Expired";
                case "Yellow":
                    return "Expiring soon (within 3 months)";
                case "Green":
                    return "Valid";
                default:
                    return "Unknown";
            }
        }

        // Format shift text
        public static string GetShiftText(Shift shift)
        {
            switch (shift)
            {
                case Shift.Morning:
                    return "Morning";
                case Shift.Afternoon:
                    return "Afternoon";
                case Shift.Evening:
                    return "Evening";
                default:
                    return "Unknown";
            }
        }
    }
}
