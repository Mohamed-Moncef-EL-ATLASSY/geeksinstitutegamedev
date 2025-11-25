class FizzBuzz
{
    static void MainFizzBuzz()
    {
        Console.Write("Enter a number between 1 and 100: ");
        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        if (number < 1 || number > 100)
        {
            Console.WriteLine("Please enter a number between 1 and 100!");
            return;
        }

        if (number % 15 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (number % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (number % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(number);
        }
    }
}

class TrianglePattern
{
    static void MainTriangle()
    {
        Console.WriteLine("Triangle Pattern:");
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}

class ReverseWord
{
    static void MainReverse()
    {
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        string reversed = "";
        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversed += word[i];
        }

        Console.WriteLine("Original: " + word);
        Console.WriteLine("Reversed: " + reversed);
    }
}
