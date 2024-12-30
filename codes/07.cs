// Day 07

using System;
using System.Collections;

namespace Days
{
    public class Day07
    {
        // Delegate Declaration
        public delegate void PrintMessage(string message);

        // Run Method
        public static void Run()
        {
            // Delegate Assignment
            PrintMessage print = Console.WriteLine;

            // Delegate Call
            print("Hi! Says the delegated.\n");

            // Writing to a file (first stored at buffer)
            // Created file is at bin > Debug > net?.?
            StreamWriter sw = new StreamWriter("krishna.txt");
            sw.WriteLine("krishna > present");
            sw.WriteLine("balaram > absent");

            // Flush to write buffers to file
            // This ensures even if program crashes later, data does not get lost
            sw.Flush();

            // Close the file
            sw.Close();

            // Reading a file
            StreamReader sr = new StreamReader("krishna.txt");
            Console.WriteLine(sr.ReadToEnd());

            // Reset file pointer
            // Read and print contents line by line
            sr.BaseStream.Position = 0;
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();

            // Close the file
            sr.Close();

            // Update file content (method 1)
            StreamWriter sa = new StreamWriter("krishna.txt", true);
            sa.WriteLine("radha > present");
            sa.Write("======================");
            sa.Flush();
            sa.Close();

            // Read and print file contents
            sr = new StreamReader("krishna.txt");
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();

            // Function to print items in collection
            static void printCollectionItems(IEnumerable collection)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine();
            }

            // List<> : similar data types (generic)
            List<string> names = new List<string>();

            // Add items to List<>
            names.Add("Asmin");
            names.Add("Prabin");
            printCollectionItems(names);

            // Remove item from List<>
            names.Remove("Asmin");
            printCollectionItems(names);

            // ArrayList : any data types (non-generic)
            ArrayList surnames = new ArrayList();

            // Add items to ArrayList
            surnames.Add("Bhattarai");
            surnames.Add("Adhikari");
            printCollectionItems(surnames);

            // Remove items from ArrayList
            surnames.Remove("Bhattarai");
            printCollectionItems(surnames);

            // Hashtable (key-value pair)
            Hashtable students = new Hashtable();

            // Add items to Hashtable
            students.Add(10, "Asmin Bhattarai");
            students.Add(26, "Prabin Adhikari");
            printCollectionItems(students);

            // Remove items from Hashtable
            students.Remove(10);
            printCollectionItems(students);

            // Hold the console window open until a key is pressed
            Console.ReadKey();
        }
    }
}