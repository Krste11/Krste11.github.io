using System;
using System.Text.RegularExpressions;

namespace TaxiManager9000.Services.Helpers
{
    public static class ValidationHelper
    {
        // Validate password (minimum length 5, must contain at least 1 digit)
        public static bool IsValidPassword(string password)
        {
            return password.Length >= 5 && Regex.IsMatch(password, @"\d");
        }

        // Validate a license plate format (e.g., ABC-1234)
        public static bool IsValidLicensePlate(string plate)
        {
            return Regex.IsMatch(plate, @"^[A-Z]{3}-\d{4}$");
        }
    }
}
