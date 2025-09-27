using System;
using System.Drawing;

namespace Lab3._2
{
    public class Trapezoid : IComparable<Trapezoid>
    {
        public static int InstanceCount { get; private set; } = 0;

        public Color FillColor { get; set; }
        public Color BorderColor { get; set; }
        public double Base1 { get; set; }  
        public double Base2 { get; set; }   
        public double Height { get; set; }  

        public Trapezoid(double base1, double base2, double height)
            : this(base1, base2, height, Color.White, Color.Black) { }

        public Trapezoid(double base1, double base2, double height, Color fillColor, Color borderColor)
        {
            Base1 = base1;
            Base2 = base2;
            Height = height;
            FillColor = fillColor;
            BorderColor = borderColor;
            InstanceCount++; 
        }

        ~Trapezoid()
        {
            InstanceCount--;
        }

        public double GetArea()
        {
            return (Base1 + Base2) / 2.0 * Height;
        }

        public double GetPerimeter()
        {
            double halfDiff = Math.Abs(Base1 - Base2) / 2.0;
            double side = Math.Sqrt(halfDiff * halfDiff + Height * Height);
            return Base1 + Base2 + 2.0 * side;
        }

        public override string ToString()
        {
            return $"Trapezoid [base1={Base1}, base2={Base2}, height={Height}, area={GetArea():F2}, perimeter={GetPerimeter():F2}]";
        }

        public int CompareTo(Trapezoid? other)
        {
            if (other == null) return 1;
            return this.GetArea().CompareTo(other.GetArea());
        }
    }
}

