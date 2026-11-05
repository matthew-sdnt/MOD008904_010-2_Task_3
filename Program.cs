using Task_3.Classes;

namespace Task_3
{
    internal class Program
    {
        static int input_int(string p_prompt) //Method to input integers. For this program, this is only here to provide function to the range restricted overload of this method.
        {
            //Variables
            int num;

            //Logic
            Console.Write(p_prompt); //Prompt user.
            while (!int.TryParse(Console.ReadLine(), out num)) //Takes input, loops if not a double.
            {
                Console.Clear();
                Console.WriteLine("Please input an integer."); //Error.
                Console.Write(p_prompt); //Reprompt user.
            }

            return num;
        }
        static int input_int(string p_prompt, int p_min, int p_max) //An overload of the input_int method that reprompts if the input is not in a certain range.
        {
            //Variables
            int num;

            //Logic
            do
            {
                num = input_int(p_prompt); //Calls the input_int method defined prior and passes the prompt in.
                if (num < p_min || num > p_max)
                {
                    Console.Clear();
                    Console.WriteLine($"Please input a number in the given range ({p_min} - {p_max}).");
                }
            } while (num < p_min || num > p_max); //Check if number is in the given range.

            return num;
        }
        static int input_greater_than_zero_int(string p_prompt)
        {
            //Variables
            int num;
            int min = 1;

            //Logic
            do
            {
                num = input_int(p_prompt); //Calls the input_int method defined prior and passes the prompt in.
                if (num < min)
                {
                    Console.Clear();
                    Console.WriteLine($"Please input a number more than {min}.");
                }
            } while (num < min); //Check if number is in the given range.

            return num;
        }
        static double input_double(string p_prompt) //Method to input doubles, this exists as a method of abstracting this logic from the main function.
        {
            //Variables
            double num;

            //Logic
            Console.Write(p_prompt); //Prompt user.
            while (!double.TryParse(Console.ReadLine(), out num)) //Takes input, loops if not a double..
            {
                Console.Clear();
                Console.WriteLine("Please input a decimal number or integer."); //Error.
                Console.Write(p_prompt); //Reprompt user.
            }

            return num;
        }
        static void print_shape_list_details(Shape[] p_shapes_list) //Method to print the details of all shapes in a given list of shapes.
        {
            for (int i = 0; i < p_shapes_list.Length; i++) //Iterate over the list to print the details alongside the shape number.
            {
                Console.WriteLine($"{p_shapes_list[i].Name} {i + 1} Area: {p_shapes_list[i].get_area():0.00}");
                if (p_shapes_list[i].Name == "Circle") //Seperate message for circles, as their perimeter is also known as a circumference.
                {
                    Console.WriteLine($"{p_shapes_list[i].Name} {i + 1} Perimeter (also known as Circumference): {p_shapes_list[i].get_perimeter():0.00}");
                }
                else
                {
                    Console.WriteLine($"{p_shapes_list[i].Name} {i + 1} Perimeter: {p_shapes_list[i].get_perimeter():0.00}");
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            //MOD008904 010-2 Task_3 - Calculator for Area and Perimeter or Rectangles, Circles, and Triangles
            //Variables
            string output_file_name; //Name of the file that will be the output .csv.
            int choice; //A variable to store the user's menu choice.
            int triangle_choice; //A variable to store the choice of what kind of triangle the user is inputting.
            int save_choice; //A variable to store whether or not the measurements made so far are to be saved to a .csv file.
            int shape_num; //A variable to store how many shapes will be inputted in a given operation.
            List<Shape> shapes = new List<Shape>(); //List to store any shapes created this session (this works as derivative classes can pass as the base class for the purposes of data structures, on top of all derivative classes having identical outward facing features as the Shapes class).
            Shape[] shapes_input = Array.Empty<Shape>(); ; //An array that stores the shapes created before they're written to the list for this session. This is an array instead of a list as it will have a set length (though being initialised to a length 0 in order to prevent an error in the later loop).
            StreamWriter stream = null;

            //Logic
            do
            {
                choice = input_int("1. Rectangle\n2. Circle\n3. Triangle\n4. View measurements\n5. Exit\nChoice: ", 1, 5);
                Console.Clear();
                switch (choice) //Determine user input.
                {
                    case 1: //Rectangle
                        shape_num = input_greater_than_zero_int("How many rectangles would you like to input the values for at once?\nNumber: ");
                        Console.Clear();
                        shapes_input = new Shape[shape_num];
                        for (int i = 0; i < shapes_input.Length; i++)
                        {
                            shapes_input[i] = new Rectangle(input_double($"Length (Rectangle {i + 1}): "), input_double($"Width (Shape {i + 1}): "));
                            Console.Clear();
                        }

                        print_shape_list_details(shapes_input);

                        Console.Write("Press enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2: //Circle
                        shape_num = input_greater_than_zero_int("How many circles would you like to input the values for at once?\nNumber: ");
                        Console.Clear();
                        shapes_input = new Shape[shape_num];
                        for (int i = 0; i < shapes_input.Length; i++)
                        {
                            shapes_input[i] = new Circle(input_double($"Radius (Circle {i + 1}): "));
                            Console.Clear();
                        }

                        print_shape_list_details(shapes_input);

                        Console.Write("Press enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3: //Triangle
                        shape_num = input_greater_than_zero_int("How many triangles would you like to input the values for at once?\nNumber: ");
                        Console.Clear();
                        shapes_input = new Shape[shape_num];
                        for (int i = 0; i < shapes_input.Length; i++)
                        {
                            triangle_choice = input_int("1. Scalene\n2. Isosceles\n3. Equilateral\nChoice: ", 1, 3);
                            Console.Clear();

                            switch (triangle_choice)
                            {
                                case 1: //Scalene
                                    shapes_input[i] = new Triangle(input_double($"Base (Triangle {i + 1}): "),
                                        input_double($"Side 1 (Triangle {i + 1}): "),
                                        input_double($"Side 2 (Triangle {i + 1}): "),
                                        input_double($"Height (Triangle {i + 1}): "));
                                    break;

                                case 2: //Isosceles
                                    shapes_input[i] = new Triangle(input_double($"Base (Triangle {i + 1}):"),
                                        input_double($"Side Length (Triangle {i + 1}):"));
                                    break;

                                case 3: //Equilateral
                                    shapes_input[i] = new Triangle(input_double($"Side Length (Triangle {i + 1}):"));
                                    break;

                                default:
                                    Console.WriteLine("Error, invalid input.");
                                    break;
                            }
                            Console.Clear();
                        }

                        print_shape_list_details(shapes_input);

                        Console.Write("Press enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4: //View all current measurements
                        Console.WriteLine("Currently stored shapes:");
                        for (int i = 0; i < shapes.Count; i++)
                        {
                            if (shapes[i].Name.Contains("Triangle")) //Unique logic for Triangles as they have unique side lengths.
                            { //Output all known info about the given Shape object.
                                Console.WriteLine($"Shape {i + 1}: {shapes[i].Name}\n" +
                                    $"Base Length: {((Triangle)shapes[i]).Sides[0]}\n" +
                                    $"Side 1: {((Triangle)shapes[i]).Sides[0]}\n" +
                                    $"Side 2: {((Triangle)shapes[i]).Sides[2]}\n" +
                                    $"Area: {shapes[i].get_area():0.00}\n" +
                                    $"Perimeter: {shapes[i].get_perimeter():0.00}\n");
                            }
                            else
                            { //Output all known info about the given Shape object.
                                Console.WriteLine($"Shape {i + 1}: {shapes[i].Name}\n" +
                                    $"Area: {shapes[i].get_area():0.00}\n" +
                                    $"Perimeter: {shapes[i].get_perimeter():0.00}\n");
                            }
                        }

                        output_file_name = $"measurements {DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.csv"; //As the date is being used as part of the file name, issues where a preexisting measurement log has the same name as the new one can never occur, assuming the user's clock does not change.
                        save_choice = input_int($"Would you like to save these measurements to an external csv file named {output_file_name}\n1. True\n2. False\nChoice: ");
                        Console.Clear();
                        switch (save_choice)
                        {
                            case 1:
                                stream = new StreamWriter(output_file_name);
                                Console.WriteLine("Measurements are going to be saved if possible.");
                                stream.WriteLine("Number,Shape Name,Length,Width,Area,Perimeter"); //For most shapes this is all that needs to be stored; for the case of triangles, while there is 3 sides to each triangle, these sides can be worked out from just the base, height, area, and perimeter, and will be worked out upon reuse.
                                for (int i = 0; i < shapes.Count; i++)
                                {
                                    stream.WriteLine($"{i + 1},{shapes[i].Name},{shapes[i].Length},{shapes[i].Width},{shapes[i].get_area():0.00},{shapes[i].get_perimeter():0.00}");
                                }
                                stream.Flush(); //Write the current contents of the stream to the file.

                                Console.WriteLine("Press enter to continue.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                Console.WriteLine("Measurements are not going to be saved.");
                                Console.WriteLine("Press enter to continue.");
                                Console.Clear();
                                Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Error, invalid input.");
                                break;
                        }
                        break;

                    case 5:
                        continue;

                    default:
                        Console.WriteLine("Error, invalid input.");
                        break;
                }

                if (shapes_input.Length != 0)
                {
                    shapes.AddRange(shapes_input);
                    Console.Write($"{shapes_input.Length} shapes written for this session\nPress enter to continue.");
                }
                Console.ReadLine();

                shapes_input = Array.Empty<Shape>(); //Reset the shape list.
                Console.Clear();
            } while (choice != 5);
        }
    }
}
