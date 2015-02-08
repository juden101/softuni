namespace MultimediaShop.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    static class Validation
    {
        public static bool ValidateId(string id)
        {
            if (id.Length > 3)
            {
                return true;
            }

            return false;
        }

        public static bool ValidateNumber(int number)
        {
            if (number < 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateNumber(double number)
        {
            if (number <= 0d)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateString(string input)
        {
            if (string.IsNullOrEmpty(input) || input == null || input == "")
            {
                return false;
            }

            return true;
        }

        public static bool ValidateList(IList<string> input)
        {
            if (input.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
