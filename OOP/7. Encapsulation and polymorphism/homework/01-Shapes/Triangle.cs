using System;

class Triangle : BasicShape
{
    private double thirdSide;

    public Triangle(double firstSide, double secondSide, double thirdSide)
        : base(firstSide, secondSide)
    {
        this.ThirdSide = thirdSide;
    }

    private double ThirdSide
    {
        get
        {
            return this.thirdSide;
        }
        set
        {
            if(value <= 0) {
                throw new ArgumentOutOfRangeException("Third side must be greater than 0!");
            }

            this.thirdSide = value;
        }
    }

    public override double CalculateArea()
    {
        var p = this.CalculatePerimeter() / 2;
        var area = Math.Sqrt(p * (p - this.Height) * (p - this.Width) * (p - this.ThirdSide));

        return area;
    }

    public override double CalculatePerimeter()
    {
        double perimeter = this.Height + this.Width + this.ThirdSide;

        return perimeter;
    }
}