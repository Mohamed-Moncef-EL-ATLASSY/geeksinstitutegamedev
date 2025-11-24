using System;

class Exercise7
{
    static void Main()
    {        
        for (int i = 1; i <= 10; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine("Number " + i + " is Even");
            }
            else
            {
                Console.WriteLine("Number " + i + " is Odd");
            }
        }
    }
}
