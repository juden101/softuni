using System;
using System.Collections;

class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable

{
    public string FirstString { get; set; }
    public string SecondString { get; set; }
    public string ThirdString { get; set; }

    public StringDisperser(string firstString, string secondString, string thirdString)
    {
        this.FirstString = firstString;
        this.SecondString = secondString;
        this.ThirdString = thirdString;
    }

    public override bool Equals(object obj)
    {
        StringDisperser stringDisperserObj = obj as StringDisperser;

        if (stringDisperserObj == null)
        {
            return false;
        }

        if (!Object.Equals(this.FirstString, stringDisperserObj.FirstString))
        {
            return false;
        }

        if (!Object.Equals(this.SecondString, stringDisperserObj.SecondString))
        {
            return false;
        }

        if (!Object.Equals(this.ThirdString, stringDisperserObj.ThirdString))
        {
            return false;
        }

        return true;
    }

    public static bool operator ==(StringDisperser stringDisperser1, StringDisperser stringDisperser2)
    {
        return StringDisperser.Equals(stringDisperser1, stringDisperser2);
    }

    public static bool operator !=(StringDisperser stringDisperser1, StringDisperser stringDisperser2)
    {
        return !(StringDisperser.Equals(stringDisperser1, stringDisperser2));
    }

    public override int GetHashCode()
    {
        return this.FirstString.GetHashCode() ^ this.SecondString.GetHashCode() ^ this.ThirdString.GetHashCode();
    }

    public override string ToString()
    {
        return String.Format("StringDisperser(First string: {0}, Second string: {1}, Third string: {2})", this.FirstString, this.SecondString, this.ThirdString);
    }

    public object Clone()
    {
        StringDisperser deepStringDisperserCopy = new StringDisperser(
            FirstString = this.FirstString,
            SecondString = this.SecondString,
            ThirdString = this.ThirdString);

        return deepStringDisperserCopy;
    }

    public int CompareTo(StringDisperser secondStringDisperser)
    {
        string firstString = this.FirstString + this.SecondString + this.ThirdString;
        string secondString = secondStringDisperser.FirstString + secondStringDisperser.SecondString + secondStringDisperser.ThirdString;

        int result = string.Compare(firstString, secondString);

        return result;
    }

    public IEnumerator GetEnumerator()
    {
        string concatinatedStrings = this.FirstString + this.SecondString + this.ThirdString;

        foreach (char character in concatinatedStrings)
        {
            yield return character + " ";
        }
    }
}