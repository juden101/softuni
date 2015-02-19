using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius;       

        public Circle(double radius)
            :base()
        {
            this.Radius = radius;
        }

        public double Radius 
        { 
            get
            {
                return this.radius;
            }
            set
            {
                if(value <=0)
                {
                    throw new ArgumentOutOfRangeException("Radius", "Radius cannot be negative or equal to 0.");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
