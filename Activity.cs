using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _durationSeconds;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Run the activity lifecycle
    public void Run()
    {
        DisplayStartMessage();
        GetDurationFromUser();
        PrepareToBegin();
        PerformActivity();
        DisplayEndMessage();
    }

    protected void DisplayStartMessage()
    {
        Console.WriteLine($"=== {_name} ===\n");
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    protected void GetDurationFromUser()
    {
        while (true)
        {
            Console.Write("Enter duration in seconds (e.g. 60): ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                _durationSeconds = seconds;
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number.");
            }
        }
        Console.WriteLine();
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {_name} for {_durationSeconds} seconds.\n");
        ShowSpinner(3);
    }

    // Animation helpers

    protected void ShowSpinner(int durationSeconds)
    {
        string spinner = @"|/-\";
        DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);
        int idx = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[idx]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            idx = (idx + 1) % spinner.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Abstract method: Each activity implements its own core logic
    protected abstract void PerformActivity();
}
