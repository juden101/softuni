using System;
using System.Text;

public struct Location
{
    public double Latitude { get; set; }
    public double Longtitude { get; set; }
    public Planet Planet { get; set; }

    public Location(double latitude, double longtitude, Planet planet) : this()
    {
        this.Latitude = latitude;
        this.Longtitude = longtitude;
        this.Planet = planet;
    }

    public override string ToString()
    {
        string output = String.Format("{0}, {1} - {2}", this.Latitude, this.Longtitude, this.Planet);
        return output;
    }
}