using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Letter Position Mapper ===\n");

        bool running = true;
        while (running)
        {
            Console.Write("Enter a word (or 'exit' to quit): ");
            string word = Console.ReadLine()?.ToLower() ?? "";

            if (word == "exit")
            {
                Console.WriteLine("Goodbye!");
                running = false;
            }
            else if (string.IsNullOrWhiteSpace(word))
            {
                Console.WriteLine("Please enter a valid word.\n");
            }
            else
            {
                var result = MapLetterPositions(word);
                DisplayResult(word, result);
                Console.WriteLine();
            }
        }
    }

    static Dictionary<char, List<int>> MapLetterPositions(string word)
    {
        var letterPositions = new Dictionary<char, List<int>>();

        for (int i = 0; i < word.Length; i++)
        {
            char letter = word[i];

            if (!letterPositions.ContainsKey(letter))
                letterPositions[letter] = new List<int>();

            letterPositions[letter].Add(i);
        }

        return letterPositions;
    }

    static void DisplayResult(string word, Dictionary<char, List<int>> result)
    {
        Console.WriteLine($"\nInput: \"{word}\"");
        Console.Write("Output: {{ ");

        int count = 0;
        foreach (var pair in result)
        {
            Console.Write($"'{pair.Key}': [{string.Join(", ", pair.Value)}]");
            count++;
            if (count < result.Count)
                Console.Write(", ");
        }
        Console.WriteLine(" }");
    }
}
