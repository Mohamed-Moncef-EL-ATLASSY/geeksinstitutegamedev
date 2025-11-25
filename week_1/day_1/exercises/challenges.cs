
//Challenges
class Challenge1 {
    static void MainChallenge1()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        
        Console.Write("Enter length: ");
        int length = int.Parse(Console.ReadLine());
        
        List<int> multiples = new List<int>();
        
        for (int i = 1; i <= length; i++)
        {
            multiples.Add(number * i);
        }
        
        Console.Write("Result: ");
        for (int i = 0; i < multiples.Count; i++)
        {
            if (i < multiples.Count - 1)
            {
                Console.Write(multiples[i] + ", ");
            }
            else
            {
                Console.WriteLine(multiples[i]);
            }
        }
    }
}

class Challenge2 {
    static void MainChallenge2()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        string result = "";
        
        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0 || input[i] != input[i - 1])
            {
                result += input[i];
            }
        }
        
        Console.WriteLine("Input: " + input);
        Console.WriteLine("Output: " + result);
    }
}