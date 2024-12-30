// Run this file or CENTRIC.csproj to select a day and view output

using System;
using Days; // Import the Days namespace to directly access Day01, Day02, etc.

class Display
{
    static void Main(string[] args)
    {
        // Set the start and end of the valid day range
        int start = 1, end = 8;

        // This variable keeps track of whether the user entered a valid day
        bool validSelection = false;

        // This loop asks the user for a valid day until they enter a correct one
        while (!validSelection)
        {
            // Prompt the user to select a day
            Console.Write($"Select a day to run ({start}-{end}): ");
            string? input = Console.ReadLine();
            Console.WriteLine();

            // Check the user input and determine if it's valid
            switch (input)
            {
                case "1":
                    // If the user selects day 1,
                    // call Day01.Run() and set validSelection to true to stop the loop
                    Day01.Run();
                    validSelection = true;
                    break;

                case "2":
                    // If the user selects day 2,
                    // call Day02.Run() and set validSelection to true to stop the loop
                    Day02.Run();
                    validSelection = true;
                    break;

                case "3":
                    // If the user selects day 3,
                    // call Day03.Run() and set validSelection to true to stop the loop
                    Day03.Run();
                    validSelection = true;
                    break;

                case "4":
                    // If the user selects day 4,
                    // call Day04.Run() and set validSelection to true to stop the loop
                    Day04.Run();
                    validSelection = true;
                    break;

                case "5":
                    // If the user selects day 5,
                    // call Day05.Run() and set validSelection to true to stop the loop
                    Day05.Run();
                    validSelection = true;
                    break;

                case "6":
                    // If the user selects day 6,
                    // call Day06.Run() and set validSelection to true to stop the loop
                    Day06.Run();
                    validSelection = true;
                    break;

                case "7":
                    // If the user selects day 7,
                    // call Day07.Run() and set validSelection to true to stop the loop
                    Day07.Run();
                    validSelection = true;
                    break;

                case "8":
                    // If the user selects day 8,
                    // call Day08.Run() and set validSelection to true to stop the loop
                    Day08.Run();
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