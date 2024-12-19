// Day 04

using System;  // Importing the System namespace to use basic functionalities like Console.WriteLine()

// Ignore from here (namespace and class setup)

namespace Days
{
    public class Day04  // Defines the Day03 class, which is where code for Day 03 will be placed
    {
        // Ignore upto here (just setting up)

        // Base class representing a Human
        public class Human
        {
            public string name;  // Public field for the name
            private string foodType;  // Private field for the foodType
            public int noOfFingers;   // Public field for the number of fingers

            // Property for FoodType with getter and setter
            // Properties allow controlled access to fields (here 'foodType')
            public string FoodType
            {
                get { return foodType; }  // Returns the value of 'foodType' field
                set { foodType = value; } // Sets the value of 'foodType' field
            }

            // Constructor for the Human class (initialize with optional default values)
            public Human(string name="Y/N", string foodType = "Momo", int noOfFingers = 5)
            {
                this.name = name;  // Set the value of the 'name' field using the constructor parameter
                FoodType = foodType;  // Set the value of the 'foodType' property using the constructor parameter
                this.noOfFingers = noOfFingers;   // Set the value of the 'noOfFinger' field using the constructor parameter
            }

            // Method to display information about the human
            public void DisplayInfo()
            {
                // Prints out the name, foodType, and noOfFingers of the Human object
                Console.WriteLine($"{name} likes {FoodType} and has {noOfFingers} fingers.");
            }
        }

        // Subclass Student which inherits from the Human class
        public class Student : Human
        {
            public string schoolName;  // A new property specific to the Student class

            // Default constructor with default values
            public Student() : base("Y/N", "Momo", 5)  // Call the base constructor with default values
            {
                this.schoolName = "Y/S";  // Set the default schoolName
            }

            // Constructor for the Student class, which uses 'base' to call the parent (Human) constructor
            public Student(string name, string foodType, int noOfFingers, string schoolName="Y/S")
                : base(name, foodType, noOfFingers)  // Calling the base class constructor
            {
                this.schoolName = schoolName;  // Initializing the new property
            }

            // Overriding DisplayInfo to include school name as well
            public new void DisplayInfo()
            {
                // Calling the base method to display the basic information
                base.DisplayInfo();
                // Adding the school information
                Console.WriteLine($"Also, {name} studies at {schoolName}.");
            }
        }

        public static void Run() // This method will be executed when we run Day04.Run()
        {
            // Creating a Human object with custom values for name, foodType, and number of fingers
            Human me = new Human("Asmin", "Chowmein", 6);
            // Display the information of the 'me' object using method
            me.DisplayInfo();

            // Creating a Human object using the default constructor (no parameters passed)
            Human defaultHuman = new Human();
            // Display the information of the defaultHuman object using method
            defaultHuman.DisplayInfo();

            // Creating a Student object with custom values
            Student meAgain = new Student(me.name, me.FoodType, me.noOfFingers, "BMC");
            // Display the information of the 'student' object
            meAgain.DisplayInfo();

            // Creating a Student object using the default constructor
            Human defaultStudent = new Student();
            // Display the information of the defaultStudent object
            defaultStudent.DisplayInfo();

            // Hold the console window open until a key is pressed
            Console.ReadKey();

            // Ignore from here (program flow ends here)
        }
    }
}

// Ignore upto here (end of the class and namespace)