// Day 08

using System;
using System.Security.Principal;

namespace Days
{
    public class Day08
    {
        // Class to demo async
        public class AsyncTest
        {
            // Just a function
            public static async void WaitAMinute()
            {
                int seconds = 2;
                Console.WriteLine($"Can you wait for {seconds} second/s?");
                await Task.Run(() => { Thread.Sleep(seconds * 1000); });
                Console.WriteLine("\nGood Picture!\n");
            }

            // Yet another Just a function
            public static void SayCheese()
            {
                Console.WriteLine("Say Cheese!\n");
            }
        }

        // Run Method
        public static void Run()
        {
            // Call functions
            AsyncTest.WaitAMinute();
            AsyncTest.SayCheese();

            // Just some data
            int[] RollNo = new int[10] {2, 4, 9, 1, 11, 33, 4, 8, 6, 3};

            // Calculate various stats using LINQ
            int MaxRollNo = (from rollNo in RollNo select rollNo).Max();
            double AvgRollNo = (from rollNo in RollNo select rollNo).Average();
            Console.WriteLine((MaxRollNo, AvgRollNo));
            // Works the same
            // Console.WriteLine(RollNo.Max());
            // Console.WriteLine(RollNo.Average());

            // Filter using LINQ
            List<int> HighRollNo = RollNo.Where(x => x > 10).ToList();
            foreach (int rollNo in HighRollNo) { Console.WriteLine(rollNo); }

            // Filter strings using LINQ
            List<string> FullNames = new List<string>()
            {
                "Nitesh Shrestha",
                "Ajay Kuikel",
                "Pradeep Manandhar",
                "Nirjal Shrestha",
                "I am mixed cases shrEstha"
            };
            List<string> Shresthas = FullNames
                .Where(x => x.ToLower().Contains("shrestha"))
                .ToList();
            foreach (string shresthas in Shresthas) { Console.WriteLine(shresthas); }

            // Sort using LINQ
            List<string> LexicalOrderShresthas = Shresthas
                .OrderBy(x => x)
                .ToList();
            foreach (string lexShresthas in LexicalOrderShresthas)
            {
                Console.WriteLine(lexShresthas);
            }

            // Reverse sort using LINQ
            List<string> RevLexicalOrderShresthas = Shresthas
                .OrderByDescending(x => x)
                .ToList();
            foreach (string revLexShresthas in RevLexicalOrderShresthas)
            {
                Console.WriteLine(revLexShresthas);
            }

            // Hold the console window open until a key is pressed
            Console.ReadKey();
        }
    }
}