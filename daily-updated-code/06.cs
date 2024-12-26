// Day 06

using System;
using System.Security.Cryptography.X509Certificates;

namespace Days
{
    public class Day06
    {
        // Make your own exception
        internal class customException : Exception
        {
            public customException()
            {
                Console.WriteLine("Custom exception!");
            }
        }

        // Partial class
        public partial class Human
        {
            public string? FoodType { get; set; }

            public void displayInfo()
            {
                Console.WriteLine("Your food type is " + FoodType + '.');
                Console.WriteLine("Also, you have " + NoOfFingers + '.');
            }
        }

        public partial class Human
        {
            public string? NoOfFingers { get; set; }
        }

        // Interface
        public interface HumanInterface
        {
            public void displayInfo() { }

        }

        public class HumanService : HumanInterface
        {
            public void displayInfo()
            {
                Console.WriteLine("I serve humankind.");
            }
        }

        // Run Method
        public static void Run()
        {
            Console.Write("Enter first number: ");
            string? firstNumber = Console.ReadLine();
            Console.Write("Enter second number: ");
            string? secondNumber = Console.ReadLine();

            // Exception handling
            try
            {
                int sum = Convert.ToInt32(firstNumber) / Convert.ToInt32(secondNumber);
                int div = Convert.ToInt32(firstNumber) / Convert.ToInt32(secondNumber);
                Console.WriteLine(sum + div);

                // throw custom exception
                throw new customException();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Non-numerical input!");
            }
            catch
            {
                Console.WriteLine("Why so many errors?");
            }
            finally
            {
                Console.WriteLine("Always get executed? Like me!");
            }

            // Create interface object
            HumanInterface notRobot = new HumanService();
            notRobot.displayInfo();

            // Hold the console window open until a key is pressed
            Console.ReadKey();
        }
    }
}