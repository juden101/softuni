using System;

public static class Utils
{

    public static void ValidateString(string value, string paramName, bool isMandatory = false)
    {
        if (value == string.Empty)
        {
            throw new ArgumentException(string.Format("{0} cannot be empty string!", paramName), paramName);
        }

        if (isMandatory && value == null)
        {
            throw new ArgumentNullException(paramName, string.Format("{0} is mandatory and cannot be null!", paramName));
        }
    }

}