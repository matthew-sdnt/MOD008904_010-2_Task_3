using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Classes
{
    internal abstract class Shape
    {
        //Fields
        protected double length;
        protected double width;
        protected string name;

        //Properties
        public string Name
        {
            get { return this.name; }
        }
        public double Length
        {
            get { return this.length; }
        }
        public double Width
        {
            get { return this.width; }
        }

        //Logic
        protected Shape(double p_length, double p_width)
        {
            this.length = p_length;
            this.width = p_width;
        }

        public abstract double get_area();
        public abstract double get_perimeter();
    }
}
