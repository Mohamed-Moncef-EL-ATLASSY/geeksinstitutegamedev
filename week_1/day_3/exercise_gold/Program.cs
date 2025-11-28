using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<string, string> birthdays = new Dictionary<string, string>
    {
        {"Ciggy", "2008/05/01"},
        {"Mohamed", "2010/10/01"},
        {"Moncef", "2002/03/01"},
        {"Diana", "2001/07/02"},
        {"Amine", "1998/08/27"}
    };

    static void Main()
    {
        Console.WriteLine("=== C# Gold Exercises ===\n");

        bool running = true;
        while (running)
        {
            Console.WriteLine("Choose an exercise:");
            Console.WriteLine("1. Birthday Look-up");
            Console.WriteLine("2. Birthdays Advanced");
            Console.WriteLine("3. Sum Sequence");
            Console.WriteLine("4. Double Dice");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            string choice = Console.ReadLine() ?? "5";

            switch (choice)
            {
                case "1":
                    Exercise1();
                    break;
                case "2":
                    Exercise2();
                    break;
                case "3":
                    Exercise3();
                    break;
                case "4":
                    Exercise4();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void Exercise1()
    {        
        Console.Write("Enter a person's name: ");
        string name = Console.ReadLine() ?? "";

        if (birthdays.ContainsKey(name))
        {
            Console.WriteLine($"{name}'s birthday is: {birthdays[name]}");
        }
        else
        {
            Console.WriteLine($"Sorry, we don't have the birthday information for {name}");
        }
    }

    // Exercise 2: Birthdays Advanced
    static void Exercise2()
    {   
        foreach (var person in birthdays.Keys)
        {
            Console.WriteLine($"  - {person}");
        }

        Console.Write("\nEnter a person's name: ");
        string name = Console.ReadLine() ?? "";

        if (birthdays.ContainsKey(name))
        {
            Console.WriteLine($"{name}'s birthday is: {birthdays[name]}");
        }
        else
        {
            Console.WriteLine($"Sorry, we don't have the birthday information for {name}");
        }
    }

    // Exercise 3: Sum Sequence
    static void Exercise3()
    {
        Console.WriteLine("This calculates: X + XX + XXX + XXXX");
        Console.WriteLine("Example: If X = 3, result = 3 + 33 + 333 + 3333 = 3702");

        Console.Write("Enter an integer X: ");
        if (int.TryParse(Console.ReadLine(), out int x))
        {
            int result = CalculateSumSequence(x);
            Console.WriteLine($"X = {x}");
            Console.WriteLine($"Result: {x} + {x}{x} + {x}{x}{x} + {x}{x}{x}{x} = {result}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }

    static int CalculateSumSequence(int x)
    {
        int xx = int.Parse(x.ToString() + x.ToString());
        int xxx = int.Parse(x.ToString() + x.ToString() + x.ToString());
        int xxxx = int.Parse(x.ToString() + x.ToString() + x.ToString() + x.ToString());
        return x + xx + xxx + xxxx;
    }

    // Exercise 4: Double Dice
    static void Exercise4()
    {
        Console.WriteLine("Simulating 100 dice throws until doubles appear...\n");

        MainSimulation();
    }

    static int ThrowDice()
    {
        Random rnd = new Random();
        return rnd.Next(1, 7);
    }

    static int ThrowUntilDoubles()
    {
        int rolls = 0;
        int dice1, dice2;

        do
        {
            dice1 = ThrowDice();
            dice2 = ThrowDice();
            rolls++;
        } while (dice1 != dice2);

        return rolls;
    }

    static void MainSimulation()
    {
        List<int> results = new List<int>();

        for (int i = 0; i < 100; i++)
        {
            int rollsNeeded = ThrowUntilDoubles();
            results.Add(rollsNeeded);
        }

        int totalThrows = results.Sum();
        double averageThrows = results.Average();

        Console.WriteLine($"Simulation Results:");
        Console.WriteLine($"  Total number of throws: {totalThrows}");
        Console.WriteLine($"  Average throws to reach doubles: {averageThrows:F2}");
        Console.WriteLine($"  Minimum throws in a simulation: {results.Min()}");
        Console.WriteLine($"  Maximum throws in a simulation: {results.Max()}");
        
        Console.WriteLine($"\nDetailed breakdown:");
        for (int i = 1; i <= results.Max(); i++)
        {
            int count = results.Count(r => r == i);
            if (count > 0)
            {
                Console.WriteLine($"  {i} throw(s): {count} time(s)");
            }
        }
    }
}
