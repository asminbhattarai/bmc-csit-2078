// Run this file or CENTRIC.csproj to select a day and view output

using System;
using Days; // Import the Days namespace to directly access Day01, Day02, etc.

class Display
{
    static void Main(string[] args)
    {
        // Set the start and end of the valid day range
        int start = 1, end = 1; // Example: only Day 1 is valid. You can extend this range as needed.

        // This variable will help us keep track of whether the user entered a valid day
        bool validSelection = false;

        // This loop will keep asking the user for a valid day until they enter a correct one
        while (!validSelection)
        {
            // Prompt the user to select a day
            Console.Write($"Select a day to run ({start}-{end}): ");
            string input = Console.ReadLine();
            Console.WriteLine();

            // Check the user input and determine if it's valid
            switch (input)
            {
                case "1":
                    // If the user selects day 1,
                    // call Days01.Run() and set validSelection to true to stop the loop
                    Day01.Run();
                    validSelection = true;
                    break;

                // Handle invalid day selection
                default:
                    Console.WriteLine("Invalid day selected. Please try again.\n");
                    break;
            }
        }
    }
}