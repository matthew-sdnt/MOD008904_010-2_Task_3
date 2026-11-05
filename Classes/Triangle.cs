using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Classes
{
    internal class Triangle : Shape
    {
        //Fields
        private double[] sides;

        //Properties
        public double[] Sides {
            get { return sides; }
        }

        //Logic
        //For the purposes of this class we will treat
        //the length and width variables as the
        //shape's base length and height.
        public Triangle(double p_base, double p_side_a, double p_side_b, double p_height) : base(p_side_a, p_height) //Scalene Triangle
        {       
            this.name = "Scalene Triangle";
            sides = new double[3]; //Initialise the sides array.
            sides[0] = p_base; //Store in input the sides array.
            sides[1] = p_side_a; //Store in input the sides array.
            sides[2] = p_side_b; //Store in input the sides array.
        }
        public Triangle(double p_base, double p_side) : base(p_base, Math.Sqrt(Math.Pow(p_side, 2) - Math.Pow(p_base / 2, 2) /* Use of the pythagorean theorem to find the height*/)) //Isosceles
        {                                                                                                     
            this.name = "Isosceles Triangle";                                                                    
            sides = new double[3]; //Initialise the sides array.
            sides[0] = p_base; //Store in input the sides array.
            sides[1] = p_side; //Store in input the sides array.
            sides[2] = p_side; //Store in input the sides array.
        }
        public Triangle(double p_side) : base(p_side, Math.Sqrt(Math.Pow(p_side, 2) - Math.Pow(p_side / 2, 2) /* Use of the pythagorean theorem to find the height*/)) //Equilateral
        {
            this.name = "Equilateral Triangle";
            sides = new double[3]; //Initialise the sides array.
            sides[0] = p_side; //Store in input the sides array.
            sides[1] = p_side; //Store in input the sides array.
            sides[2] = p_side; //Store in input the sides array.
        }
        public override double get_area()
        {
            return (length * width) / 2; //Where length and width are representative of the base and height of the triangle respectively.
        }
        public override double get_perimeter()
        {
            return sides.Sum();
        }
    }
}
