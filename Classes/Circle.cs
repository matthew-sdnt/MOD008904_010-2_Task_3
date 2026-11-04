using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Classes
{
    internal class Circle : Shape
    {
        public Circle(double p_radius) : base(p_radius, p_radius * 2) //Circles do not use a traditional length and width, we are accounting for this
        {                                                             //externally by only have p_radius on the constructor but when it comes to this
            this.name = "Circle";                                     //class, it still has a length and width field, for this case the length to be
        }                                                             //treated as the radius, and the width as the diameter.
      
        public override double get_area()
        {
            return Math.PI * length * length; //Where length is treated as the radius.
        }
        public override double get_perimeter()
        {
            return Math.PI * width; //Where width is treated as the diameter
        }
    }
}
