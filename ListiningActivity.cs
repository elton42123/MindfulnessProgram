using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        Random rnd = new Random();
        string prompt = _prompts[rnd.Next(_prompts.Count)];

        Console.WriteLine("Prompt:");
        Console.WriteLine("--> " + prompt);
        Console.WriteLine("\nYou will have a few seconds to think before listing begins.");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_durationSeconds);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            int secondsLeft = (int)(endTime - DateTime.Now).TotalSeconds;
            Console.Write($"({secondsLeft}s left) > ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input.Trim());
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }
}
