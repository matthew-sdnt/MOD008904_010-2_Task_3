using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Classes
{
    internal class Rectangle : Shape
    {
        public Rectangle(double p_length, double p_width) : base(p_length, p_width)
        {
            this.name = "Rectangle";
        }
        public override double get_area()
        {
            return length * width;
        }
        public override double get_perimeter()
        {
            return (length * 2) + (width * 2);
        }
    }
}
