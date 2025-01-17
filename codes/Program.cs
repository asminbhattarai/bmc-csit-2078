// Run this file or CENTRIC.csproj to select a day and view output

using System;
using Days; // Import the Days namespace to directly access Day01, Day02, etc.

class Display
{
    static void Main(string[] args)
    {
        // Set the start and end of the valid day range
        int start = 1, end = 9;

        // This variable keeps track of whether the user entered a valid day or 0
        bool keepGoing = true;

        // This loop asks the user for a valid day until they enter a correct one or 0
        while (keepGoing)
        {
            // Prompt the user to select a day
            Console.Write($"Select a day to run ({start}-{end}) or 0 to exit: ");
            string? input = Console.ReadLine();
            Console.Clear();

            // Check the user input and determine if it's valid
            switch (input)
            {
                case "0":
                    // If the user enters 0,
                    // exit the loop
                    keepGoing = false;
                    break;

                case "1":
                    // If the user selects day 1,
                    // call Day01.Run()
                    Day01.Run();
                    break;

                case "2":
                    // If the user selects day 2,
                    // call Day02.Run()
                    Day02.Run();
                    break;

                case "3":
                    // If the user selects day 3,
                    // call Day03.Run()
                    Day03.Run();
                    break;

                case "4":
                    // If the user selects day 4,
                    // call Day04.Run()
                    Day04.Run();
                    break;

                case "5":
                    // If the user selects day 5,
                    // call Day05.Run()
                    Day05.Run();
                    break;

                case "6":
                    // If the user selects day 6,
                    // call Day06.Run()
                    Day06.Run();
                    break;

                case "7":
                    // If the user selects day 7,
                    // call Day07.Run()
                    Day07.Run();
                    break;

                case "8":
                    // If the user selects day 8,
                    // call Day08.Run()
                    Day08.Run();
                    break;

                case "9":
                    // If the user selects day 9,
                    // call Day09.Run()
                    Day09.Run();
                    break;

                // Handle invalid day selection
                default:
                    Console.WriteLine("Invalid day selected. Please try again.\n");
                    break;
            }

            // Few lines for better readability
            Console.Write("\n\n");
        }
    }
}