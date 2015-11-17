public static class StringExtensions
{
    public static string CapitaliseEveryWord(this string value)
    {
        string[] words = value.ToLower().Split();

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
        }

        return string.Join(" ", words);
    }
}