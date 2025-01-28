using System;
using System.Reflection; // Required for reflection
using Days; // Import the Days namespace to directly access Day01, Day02, etc.

class Display
{
    static void Main(string[] args)
    {
        // Set the start and end of the valid day range
        int start = 1, end = 11;  // You can change the 'end' to control the range of days
        bool keepGoing = true;  // This variable keeps track of whether the user entered a valid day or 0

        // This loop asks the user for a valid day until they enter a correct one or 0
        while (keepGoing)
        {
            // Prompt the user to select a day
            Console.Write($"Select a day to run ({start}-{end}) or 0 to exit: ");
            string? input = Console.ReadLine();  // Get user input
            Console.Clear();  // Clear the console for better readability

            // Check the user input and determine if it's valid
            if (int.TryParse(input, out int day))
            {
                if (day == 0)
                {
                    // If the user enters 0, exit the loop
                    keepGoing = false;
                }
                else if (day >= start && day <= end)
                {
                    // Build the name of the DayXX class dynamically (e.g., Day01, Day02, ...)
                    string methodName = $"Day{day:D2}";  // Format day as "01", "02", etc.

                    // Use reflection to find the corresponding DayXX class
                    Type? dayType = Type.GetType($"Days.{methodName}");

                    // If the type is found, invoke the Run method
                    if (dayType != null)
                    {
                        // Get the 'Run' method of the DayXX class
                        MethodInfo? methodInfo = dayType.GetMethod("Run");

                        if (methodInfo != null)
                        {
                            // Call the Run method
                            methodInfo.Invoke(null, null);
                        }
                    }
                    else
                    {
                        // If DayXX is not found, display an error message
                        Console.WriteLine("Day not found.\n");
                    }
                }
                else
                {
                    // Handle invalid day selection (out of range)
                    Console.WriteLine("Invalid day selected. Please try again.\n");
                }
            }
            else
            {
                // Handle invalid input that isn't a number
                Console.WriteLine("Invalid input. Please try again.\n");
            }

            // Few lines for better readability
            Console.Write("\n\n");
        }
    }
}