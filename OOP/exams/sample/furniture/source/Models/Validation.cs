namespace FurnitureManufacturer.Models
{
    using System;
    using System.Linq;

    public static class Validation
    {
        public static void NullOrEmpty(string property)
        {
            if(string.IsNullOrEmpty(property))
            {
                throw new ArgumentNullException(property + " cannot be null or empty.");
            }
        }

        public static void MinStringLength(string property, string propertyValue, int minimalLength)
        {
            if (propertyValue.Length < minimalLength)
            {
                throw new ArgumentOutOfRangeException(property + " must be atleast " + minimalLength + " characters long.");
            }
        }

        public static void MinValue(string property, decimal propertyValue, decimal minimalValue)
        {
            if (propertyValue <= minimalValue)
            {
                throw new ArgumentOutOfRangeException(property + " must be Greater than " + minimalValue + ".");
            }
        }

        public static void RegistrationNumber(string propertyValue)
        {
            if (propertyValue.Length != 10 || !propertyValue.All(char.IsDigit))
            {
                throw new ArgumentOutOfRangeException("Registration number must be exactly 10 symbols and must contain only digits.");
            }
        }
    }
}
