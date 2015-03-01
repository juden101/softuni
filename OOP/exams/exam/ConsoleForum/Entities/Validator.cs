namespace ConsoleForum.Entities
{
    using System;

    public static class Validator
    {
        public static void NotNegativeNumber(int number)
        {
            if (number < 0)
            {
                throw new InvalidOperationException("You can not pass negative number.");
            }
        }

        public static void NotEmptyString(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                throw new InvalidOperationException("You can not pass empty string.");
            }
        }
    }
}
