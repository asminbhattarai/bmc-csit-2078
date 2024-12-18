# Day 1 - 8th Dec, 2024

## Write about:

### Constants

### Arrays

### Loops (while, do-while, for, foreach)

### Jump Statements (break, continue, return, goto)

### Switch Statement

### Functions/Methods

> #### ref and out parameters
> #### method signature
> #### accessors
> #### return type

---

### Code

```C#

// Function to add two numbers and return the result
public static int Add(int a, int b)
{
    return a + b;  // Simply returns the sum of a and b
}

// Function with ref and out parameters
public static void RandomFxn(ref int a, out int b)
{
    a += 5;  // Modifies 'a' by adding 5 to it
    b = 5;   // Assigns the value 5 to 'b'
}

// Run method that runs the code for Day 03 in Program.cs
public static void Run()
{
    // Arrays: Arrays store multiple values of the same type
    int[] ageArray = new Int32[5] { 27, 25, 21, 22, 21 };  // Array of ages
    string[] nameArray = new string[5] { "Aashutosh", "Asmin", "Anjan", "Ajay", "Rabin" };  // Array of names

    // For loop: Loops through the array and prints each name and corresponding age
    for (int i = 0; i < ageArray.Length; i++)  // Loops through the array based on its length
    {
        Console.WriteLine(nameArray[i] + "'s age: " + ageArray[i]);
    }
    Console.WriteLine();

    // For loop with C-style formatting: Using placeholders in the output string
    for (int i = 0; i < nameArray.Length; i++)
    {
        Console.WriteLine("Age of {0} is {1}.", nameArray[i], ageArray[i]);
    }
    Console.WriteLine();

    // While loop: Another type of loop that runs as long as the condition is true
    int j = 0;
    while (j < nameArray.Length)  // Continues until j is equal to the length of nameArray
    {
        Console.WriteLine("Age of {0} was {1}.", nameArray[j], ageArray[j]);
        j++;  // Increment the counter
    }
    Console.WriteLine();

    // Do-while loop: Similar to while, but it runs at least once before checking the condition
    j--;  // Decrease j so we can loop backwards in the next section
    do
    {
        Console.WriteLine("{0}'s age was {1}.", nameArray[j], ageArray[j]);
        j--;  // Decrement the counter for the reverse loop
    } while (j >= 0);  // Continue while j is still non-negative
    Console.WriteLine();

    // Foreach loop: A loop that automatically iterates through every element of a collection
    foreach (int i in ageArray)  // Loops through each age in the ageArray
    {
        Console.WriteLine("{0}: {1}", nameArray[Array.IndexOf(ageArray, i)], i);  // Prints the corresponding name and age
    }
    Console.WriteLine();

    // Break and Continue: Control flow inside loops
    for (int i = 0; i <= 10; i++)  // Loop from 0 to 10
    {
        insideLoop:
        if (i % 2 == 0) continue;  // Skip even numbers using 'continue'
        if (i == 7) break;  // Stop the loop when i equals 7 using 'break'
        if (i == 1)  // Skip printing 1 to console using 'label'
        {
            i++;
            goto insideLoop;
        }
        Console.WriteLine(i);  // Print the current value of i
    }
    Console.WriteLine();

    // Switch statement: A way to execute different blocks of code based on the value of a variable
    char chr = 'a';
    switch (chr)  // Check the value of chr
    {
        case 'a':
            Console.WriteLine('A');  // If chr is 'a', print 'A'
            break;
        case 'b':
            Console.WriteLine('B');  // If chr is 'b', print 'B'
            break;
        case 'c':
            Console.WriteLine('C');  // If chr is 'c', print 'C'
            break;
        default:
            Console.WriteLine("Others");  // If none of the above cases match, print "Others"
            break;
    }
    Console.WriteLine();

    // Constants: Constants store values that cannot change once they are assigned
    const float PI = 3.14159f;  // The value of PI is constant and won't change
    Console.WriteLine("\nPI: {0}", PI);  // Print the value of PI

    // Function example: calling the Add function to add two numbers
    int a = 12, b = 13;
    Console.WriteLine("\nSum of {0} and {1} is {2}.", a, b, Add(a, b));  // Print the sum of 12 and 13

    // Function with ref and out: calling RandomFxn
    int c = 10, d;  // Initialize variables for the function
    RandomFxn(ref c, out d);  // Pass 'c' by reference, and 'd' by output
    Console.WriteLine("Result of RandomFxn: {0} + {1} = {2}", c, d, c + d);  // Print the results
}

```