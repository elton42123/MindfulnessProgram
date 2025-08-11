using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("===================");

        bool exitRequested = false;

        while (!exitRequested)
        {
            Console.WriteLine("\n1) Breathing Activity");
            Console.WriteLine("2) Reflection Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Exit");
            Console.Write("Select an option: ");

            string? input = Console.ReadLine();
            Console.WriteLine();

            Activity? activity = null;

            switch (input)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    exitRequested = true;
                    Console.WriteLine("Goodbye!");
                    continue;
                default:
                    Console.WriteLine("Invalid selection, try again.");
                    continue;
            }

            activity.Run();
        }
    }
}
