using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercise in class Exercise.cs
            // To Create Opject ===> Exercise Ex = new Exercise();
            // Use EX.Exercise_01 to show any exercsie ( 01 is number of exercise )
            
            RunEx();
          
        }

        // devlab3 can't use any class because they need only 1 .cs file
        // so i have to create RunEx function
        static void RunEx()
        {
            Console.WriteLine(6 / 2 * (2 + 1));
        }
    }
}