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

        static void Main(string[] args)
        {
            //MOD008904 010-2 Task_3 - Calculator for Area and Perimeter or Rectangles, Circles, and Triangles
            //Variables

            //Logic

        }
    }
}
