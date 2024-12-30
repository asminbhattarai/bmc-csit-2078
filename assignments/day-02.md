# Day 2 - 9th Dec, 2024

## Write about:

### Data Types

### Type Casting (Type Conversion)

### Convert Class (Specialized Type Conversion)

### Errors: Compile-Time and Runtime

### String Class and Its Functions (at least ten)

---

## Code

```C#

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
int xor = aInt ^ bInt;  // XOR operation (exclusive OR)
int and = aInt & bInt;  // AND operation
int notA = ~aInt;  // NOT operation (flip bits)
int notB = ~bInt;  // NOT operation (flip bits)
int lShift = aInt << bInt;  // Left shift: Shift bits to the left (multiply by powers of 2)
int rShift = aInt >> bInt;  // Right shift: Shift bits to the right (divide by powers of 2)

// Print the results of the bitwise operations
Console.WriteLine("\nBitwise XOR of " + aInt + " and " + bInt + " is " + xor + ".");
Console.WriteLine("Bitwise AND of " + aInt + " and " + bInt + " is " + and + ".");
Console.WriteLine("Bitwise NOT of " + aInt + " is " + notA + " and of " + bInt + " is " + notB + ".");
Console.WriteLine("Bitwise left shift of " + aInt + " by " + bInt + " is " + lShift + ".");
Console.WriteLine("Bitwise right shift of " + aInt + " by " + bInt + " is " + rShift + ".");

// String manipulation: Demonstrating basic string operations
Console.Write("\nEnter your name: ");
string str = Console.ReadLine();  // Read the name input as a string

// Convert the name to uppercase and lowercase, and print the output
string upperStr = str.ToUpper();
string lowerStr = str.ToLower();
Console.WriteLine("Your name in uppercase is " + upperStr + ".");
Console.WriteLine("Your name in lowercase is " + lowerStr + ".");

// Substring operation: Extract part of the string based on user input
Console.Write("Enter start position: ");
byte start = Convert.ToByte(Console.ReadLine());  // Read the start position as a byte
Console.Write("Enter number of chars to print: ");
byte len = Convert.ToByte(Console.ReadLine());  // Read the length of the substring as a byte

string subStr = str.Substring(start, len);  // Extract the substring based on the start position and length
Console.WriteLine("From position " + start + " with " + len + " characters, your name cuts to " + subStr + ".");

```