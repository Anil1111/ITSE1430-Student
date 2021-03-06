﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1
{
    class Program
    {
        static void Main( string[] args )
        {
            bool notQuit;
            do
            {
                notQuit = DisplayMenu();
            }
            while (notQuit);

           //PlayWithStrings();

        }

        private static void PlayWithStrings()
        {
            string hoursString = "10";
            //int hours = Int32.Parse(hoursString);
            //int hours;
            //bool result = Int32.TryParse(hoursString, out hours);
            //bool result = Int32.TryParse(hoursString, out int hours);

            //Examples of ToString()
            //hoursString = hours.ToString();
            //3.14.ToString();
            //456.ToString();
            //Console.ReadLine().ToString();

            string message = "Hello\tworld";
            string filePath = "C:\\Temp\\Test";

            //Verbatim strings
            filePath = @"C:\Temp\Test";

            //Concat
            string firstName = "Bob";
            string lastName = "Smith";
            string name = firstName + " " + lastName;

            //Strings are immutable - this produces a new string
            //name = "Hello " + name;
            Console.WriteLine("Hello " + name); //Method 1
            Console.WriteLine("Hello {0} {1}", firstName, lastName);//Method 2
            string str = String.Format("Hello {0} {1},", firstName, lastName); //Method 3
            Console.WriteLine(str);

            Console.WriteLine($"Hello {firstName} {lastName}"); //Method 4

            //Null vs. Empty
            string missing = null; //Nothing exist
            string empty = ""; //Empty value
            string empty2 = String.Empty; //Same as above, rare use case

            //Checking for empty strings
            //if (firstName.Length == 0)
            //if (firstName != null && firstName != "")
            if (!String.IsNullOrEmpty(firstName))
                Console.WriteLine(firstName);

            //Other stuff
            string upperName = firstName.ToUpper(); //Upper case the string
            string lowerName = firstName.ToLower(); //Lower case the string

            //Comparison
            bool areEqual = firstName == lastName;
            areEqual = firstName.ToLower() == lastName.ToLower();
            areEqual = String.Compare(firstName, lastName, true) == 0; //Compares two strings that ignores case sensitivity

            bool startsWithA = firstName.StartsWith("A");
            bool endsWithA = firstName.EndsWith("A");
            bool hasA = firstName.IndexOf("A") >= 0;
            string subset = firstName.Substring(4);

            //Clean up
            string cleanMe = firstName.Trim(); //TrimStart, TrimEnd
            string makeLonger = firstName.PadLeft(20); //PadRight

        }

        private static bool DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("E)dit Movie");
                Console.WriteLine("D)elet Movie");
                Console.WriteLine("V)iew Movie");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();
                switch (input[0])
                {
                    case 'a':  
                    case 'A': AddMovie(); return true;

                    case 'e':  
                    case 'E': EditMovie(); return true;

                    case 'd':  
                    case 'D': DeleteMovie(); return true;

                    case 'v': 
                    case 'V': ViewMovie(); return true;

                    case 'q': 
                    case 'Q': return false;

                    default: Console.WriteLine("Please enter a valid value.\n"); break;
                };
            };
        }

        private static void PlayWithArrays()
        {
            int count = ReadInt32("How many names? ", 1);

            string[] names = new string[count];
            for(int index = 0; index < count; ++index)
            {
                Console.WriteLine("Name? ");
                names[index] = Console.ReadLine();
            };

            foreach (string name in names)
            //for(int index = 0; index < names.Length; ++index)
            {
                //Console.WriteLine(names[index]);
                Console.WriteLine(name);
            }
        }

        private static void AddMovie()
        {
            name = ReadString("Enter a name: ", true);
            description = ReadString("Enter the description: ");
            runLength = ReadInt32("Enter the length (in minutes): ", 0);
        }

        private static void EditMovie()
        {
            Console.WriteLine("Edit Movie");
        }

        private static void DeleteMovie()
        {
            Console.WriteLine("Delete Movie");
        }

        private static void ViewMovie()
        {
            Console.WriteLine("View Movie");
        }

        private static int ReadInt32 (string message, int minValue)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int result))
                {
                    if (result >= minValue)
                        return result;
                };
                Console.WriteLine($"You must enter an integer value >= {minValue}");
            };
        }

        private static string ReadString( string message )
        {
           return ReadString(message, false);
        }

        private static string ReadString( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                Console.WriteLine("You must enter a value.");
            };
        }

        //A movie
        static string name;
        static string description;
        static int runLength;
        static DateTime releaseDate;
    }
}
