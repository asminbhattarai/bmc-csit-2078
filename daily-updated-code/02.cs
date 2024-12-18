// Day 02

using System;

// Ignore from here (this section is setting up the namespace and class structure)

namespace Days
{
    public class Day02  // Defines the Day01 class, which is where code for Day 02 will be placed
    {
        public static void Run()  // This method will be executed when we run Day02.Run()
        {
            // Ignore upto here (just setting up)

            // Input two numbers from the user
            Console.Write("Enter first number: ");
            string aStr = Console.ReadLine();  // Read the first number input as a string
            Console.Write("Enter second number: ");
            string bStr = Console.ReadLine();  // Read the second number input as a string

            // Convert string inputs to integers
            int aInt = Convert.ToInt32(aStr);  // Convert the first string to an integer
            int bInt = Convert.ToInt32(bStr);  // Convert the second string to an integer

            // Sum operation
            int sum = aInt + bInt;

            // Print the sum of the two numbers
            Console.WriteLine("Your sum is " + sum + ".");

            // Print the greater of the two numbers
            Console.Write("Greater number is ");
            if (aInt > bInt)
            {
                Console.WriteLine(aInt + ".");
            }
            else
            {
                Console.WriteLine(bInt + ".");
            }

            // Bitwise operations: These are low-level operations that work on the binary representation of numbers

            // XOR operation (exclusive OR): Returns 1 if the bits are different, 0 if the same
            int xor = aInt ^ bInt;
            // AND operation: Returns 1 if both bits are 1, otherwise returns 0
            int and = aInt & bInt;
            // NOT operation: Flips the bits (0s become 1s and 1s become 0s)
            int notA = ~aInt, notB = ~bInt;
            // Left shift: Shifts bits to the left, multiplying the number by powers of 2
            int lShift = aInt << bInt;
            // Right shift: Shifts bits to the right, dividing the number by powers of 2
            int rShift = aInt >> bInt;

            // Print the results of the bitwise operations
            Console.WriteLine("\nBitwise XOR of " + aInt + " and " + bInt + " is " + xor + ".");
            Console.WriteLine("Bitwise AND of " + aInt + " and " + bInt + " is " + and + ".");
            Console.WriteLine("Bitwise NOT of " + aInt + " is " + notA + " and of " + bInt + " is " + notB + ".");
            Console.WriteLine("Bitwise left shift of " + aInt + " by " + bInt + " is " + lShift + ".");
            Console.WriteLine("Bitwise right shift of " + aInt + " by " + bInt + " is " + rShift + ".");

            // String manipulation: Demonstrating basic string operations

            // Input the user's name
            Console.Write("\nEnter your name: ");
            string str = Console.ReadLine();  // Read the name input as a string

            // Convert the name to uppercase and lowercase, and print the output
            string upperStr = str.ToUpper();
            string lowerStr = str.ToLower();
            Console.WriteLine("Your name in uppercase is " + upperStr + ".");
            Console.WriteLine("Your name in lowercase is " + lowerStr + ".");

            // Substring operation: Extract part of the string based on user input

            // Ask for the start position of the substring
            Console.Write("Enter start position: ");
            byte start = Convert.ToByte(Console.ReadLine());  // Read the start position as a byte
            Console.Write("Enter number of chars to print: ");
            byte len = Convert.ToByte(Console.ReadLine());  // Read the length of the substring as a byte
            string subStr = str.Substring(start, len);  // Extract the substring based on the start position and length
            Console.WriteLine("From position " + start + " with " + len + " characters, your name cuts to " + subStr + ".");

            // Hold the console window open until a key is pressed
            Console.ReadKey();

            // Ignore from here (rest of the code handles cleanup and closure)
        }
    }
}

// Ignore upto here (closing braces for the class and namespace)