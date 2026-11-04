using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Classes
{
    internal class Triangle : Shape
    {
        //Fields
        private double[] sides;

        //Logic
        public Triangle(double side_a, double side_b, double side_c, double p_height) : base(side_a, p_height) //For the purposes of this class we will treat
        {                                                                                                      //the length and width variables as the
            this.name = "Triangle";                                                                            //shape's base length and height.
            sides = new double[3]; //Initialise the sides array.
            sides[0] = side_a; //Store in input the sides array.
            sides[1] = side_b; //Store in input the sides array.
            sides[2] = side_c; //Store in input the sides array.
        }
        public override double get_area()
        {
            return (length * width) / 2;
        }
        public override double get_perimeter()
        {
            return sides.Sum();
        }
    }
}
