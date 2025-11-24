using System;

class Exercise1
{
    static void Main1()
    {
        Console.WriteLine("Welcome to C# Programming!");
    }
}

class Exercise2
{
    static void Main2()
    {
        string name = "Mohamed Moncef EL ATLASSY";
        int age = 23;
        
        Console.WriteLine("My name is " + name + " and I am " + age + " years old.");
    }
}

class Exercise3
{
    static void Main3()
    {
        int num1 = 10;
        int num2 = 5;
        int sum = num1 + num2;
        
        Console.WriteLine("num1: " + num1);
        Console.WriteLine("num2: " + num2);
        Console.WriteLine("Sum: " + sum);
    }
}

class Exercise4
{
    static void Main4()
    {
        int userAge = 20;
        
        if (userAge >= 18)
        {
            Console.WriteLine("Access Granted.");
        }
        else
        {
            Console.WriteLine("Access Denied.");
        }
    }
}

class Exercise5
{
    static void Main5()
    {
        int countdown = 10;
        
        while (countdown >= 1)
        {
            Console.WriteLine(countdown);
            countdown--;
        }
        
        Console.WriteLine("Liftoff!");
    }
}

class Exercise6
{
    static void SayHello(string name)
    {
        Console.WriteLine("Hello, " + name + "!");
    }
    
    static void Main6()
    {
        SayHello("Mohamed");
        SayHello("Moncef");
        SayHello("EL ATLASSY");
    }
}

class Exercise7
{
    static void Main7()
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
