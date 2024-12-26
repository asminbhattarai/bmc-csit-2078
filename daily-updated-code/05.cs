using System;

namespace Days
{
    public class Day05
    {
        // Enumeration for students
        public enum Students
        {
            Apratim,
            Asmin,
            Bibek
        }

        // Abstract class representing a Human
        public abstract class Human
        {
            // Fields
            public string Name { get; set; }
            private string? foodType;
            public int NoOfFingers { get; set; }

            // Property for foodType
            public string FoodType
            {
                get => foodType ?? "Unknown";
                set => foodType = value;
            }

            // Constructor
            public Human(string name = "Unknown", string foodType = "Unknown", int noOfFingers = 5)
            {
                this.Name = name;
                this.FoodType = foodType;
                this.NoOfFingers = noOfFingers;
            }

            // Virtual method for displaying info
            public virtual void DisplayInfo()
            {
                Console.WriteLine($"{Name} likes {FoodType} and has {NoOfFingers} fingers.");
            }

            // Abstract method to be implemented by derived classes
            public abstract void Speak();

            // A function
            public void SpeakWithGreeting()
            {
                Console.WriteLine($"{Name} speaks: 'Welcome!'");
            }
        }

        // Sealed class that cannot be inherited from
        public sealed class Student : Human
        {
            // Additional field for the student
            public string SchoolName { get; set; }
            public string ContactInfo { get; set; }

            // Constructor
            public Student(string name, string foodType, int noOfFingers, string schoolName, string contactInfo)
                : base(name, foodType, noOfFingers)
            {
                this.SchoolName = schoolName;
                this.ContactInfo = contactInfo;
            }

            // Overriding DisplayInfo to include school name
            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"{Name} studies at {SchoolName}. Contact: {ContactInfo}");
            }

            // Implementing abstract method Speak
            public override void Speak()
            {
                Console.WriteLine($"{Name} says: 'I am a student at {SchoolName}.'");
            }

            // Method Overload: DisplayInfo with a different signature
            public void DisplayInfo(string additionalInfo)
            {
                Console.WriteLine($"{Name} enjoys {additionalInfo}. Studies at {SchoolName}. Contact: {ContactInfo}");
            }

            // Method hiding using new keyword to hide base method
            public new void SpeakWithGreeting()
            {
                Console.WriteLine($"{Name} speaks: 'Welcome to {SchoolName}!' (Hidden method)");
            }
        }

        // Struct to store student profile information (uses enum)
        public struct StudentProfile
        {
            public int RollNo;
            public Students StudentName;  // Using enum to store student's name
            public string Contact; // Using contact info

            // Constructor to initialize the StudentProfile struct
            public StudentProfile(int rollNo, Students studentName, string contact)
            {
                this.RollNo = rollNo;
                this.StudentName = studentName;
                this.Contact = contact;
            }

            // Method to display the student profile information
            public void DisplayProfile()
            {
                Console.WriteLine($"Student: {StudentName}, Roll Number: {RollNo + 1}, Contact: {Contact}");
            }
        }

        public static void Run()
        {
            // Using Enum in Struct
            StudentProfile apratim = new StudentProfile(1, Students.Apratim, "apratim@example.com");
            apratim.DisplayProfile();

            // Creating and displaying Student objects
            Student student = new Student("Asmin", "Chowmein", 6, "BMC", "asmin@example.com");
            student.DisplayInfo();   // Calls overridden DisplayInfo
            student.Speak();         // Calls overridden Speak method

            // Method Overload example
            student.DisplayInfo("Reading books");

            // Demonstrating Method Hiding using new keyword
            student.SpeakWithGreeting();  // This calls the hidden SpeakWithGreeting method

            // Hold the console window open until a key is pressed
            Console.ReadKey();
        }
    }
}