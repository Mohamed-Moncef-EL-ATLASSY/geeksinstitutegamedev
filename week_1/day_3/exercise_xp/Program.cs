using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Exercise1();
        Exercise2();
        Exercise3();
        Exercise4();
        Exercise5();
        Exercise6();
        Exercise7();
        Exercise8();
        Exercise9();
        Exercise10();
        Exercise11();
        Exercise12();
    }

    static void Exercise1()
    {
        
        List<string> keys = new List<string> { "Ten", "Twenty", "Thirty" };
        List<int> values = new List<int> { 10, 20, 30 };
        
        Dictionary<string, int> result = new Dictionary<string, int>();
        
        for (int i = 0; i < keys.Count; i++)
        {
            result[keys[i]] = values[i];
        }
        
        Console.WriteLine("Result Dictionary:");
        foreach (var pair in result)
        {
            Console.WriteLine($"  \"{pair.Key}\": {pair.Value}");
        }
    }

    static void Exercise2()
    {
        
        Dictionary<string, int> family = new Dictionary<string, int>
        {
            {"rick", 43}, {"beth", 13}, {"morty", 5}, {"summer", 8}
        };
        
        int totalCost = 0;
        
        Console.WriteLine("Ticket prices:");
        foreach (var member in family)
        {
            int age = member.Value;
            int ticketPrice = GetTicketPrice(age);
            totalCost += ticketPrice;
            Console.WriteLine($"  {member.Key} (age {age}): ${ticketPrice}");
        }
        
        Console.WriteLine($"Total family cost: ${totalCost}");
    }

    static int GetTicketPrice(int age)
    {
        if (age < 3) return 0;
        if (age <= 12) return 10;
        return 15;
    }

    // Exercise 3: Zara Brand Dictionary
    static void Exercise3()
    {
        
        var brand = new Dictionary<string, object>
        {
            {"name", "Zara"},
            {"creation_date", 1975},
            {"creator_name", "Amancio Ortega Gaona"},
            {"type_of_clothes", new List<string>{"men", "women", "children", "home"}},
            {"international_competitors", new List<string>{"Gap", "H&M", "Benetton"}},
            {"number_stores", 7000},
            {"major_color", new Dictionary<string, List<string>>
                {
                    {"France", new List<string>{"blue"}},
                    {"Spain", new List<string>{"red"}},
                    {"US", new List<string>{"pink", "green"}}
                }
            }
        };

        // 1. Change number_stores to 2
        brand["number_stores"] = 2;
        Console.WriteLine("1. Changed number_stores to 2");

        // 2. Print sentence about clients using type_of_clothes
        var clothes = (List<string>)brand["type_of_clothes"];
        Console.WriteLine($"2. Zara sells clothes for: {string.Join(", ", clothes)}");

        // 3. Add country_creation
        brand["country_creation"] = "Spain";
        Console.WriteLine("3. Added country_creation: Spain");

        // 4. Check and add international_competitors
        if (brand.ContainsKey("international_competitors"))
        {
            var competitors = (List<string>)brand["international_competitors"];
            if (!competitors.Contains("Desigual"))
            {
                competitors.Add("Desigual");
                Console.WriteLine("4. Added Desigual to international_competitors");
            }
        }

        // 5. Delete creation_date
        brand.Remove("creation_date");
        Console.WriteLine("5. Deleted creation_date");

        // 6. Print last international competitor
        var competitorsList = (List<string>)brand["international_competitors"];
        Console.WriteLine($"6. Last competitor: {competitorsList[competitorsList.Count - 1]}");

        // 7. Print major colors in US
        var majorColors = (Dictionary<string, List<string>>)brand["major_color"];
        var usColors = majorColors["US"];
        Console.WriteLine($"7. Major colors in US: {string.Join(", ", usColors)}");

        // 8. Print number of key-value pairs
        Console.WriteLine($"8. Number of key-value pairs: {brand.Count}");

        // 9. Print all keys
        Console.WriteLine($"9. All keys: {string.Join(", ", brand.Keys)}");

        // 10. Merge another dictionary
        var more_on_zara = new Dictionary<string, object>
        {
            {"creation_date", 1975},
            {"number_stores", 10000}
        };

        foreach (var item in more_on_zara)
        {
            brand[item.Key] = item.Value;
        }

        Console.WriteLine($"10. After merge - number_stores: {brand["number_stores"]}");
        Console.WriteLine("    (value was overwritten from 2 to 10000)");
    }

    // Exercise 4: Some Geography
    static void Exercise4()
    {
        
        DescribeCity("Reykjavik");
        DescribeCity("New York", "USA");
        DescribeCity("Paris", "France");
        DescribeCity("Tokyo", "Japan");
    }

    static void DescribeCity(string city, string country = "Iceland")
    {
        Console.WriteLine($"  {city} is in {country}.");
    }

    // Exercise 5: Random Number Guess
    static void Exercise5()
    {
        
        Random rnd = new Random();
        int secretNumber = rnd.Next(1, 101);
        
        Console.Write("  Guess a number (1-100): ");
        if (int.TryParse(Console.ReadLine(), out int userGuess))
        {
            GuessNumber(userGuess, secretNumber);
        }
        else
        {
            Console.WriteLine("  Invalid input.");
        }
    }

    static void GuessNumber(int guess, int secretNumber)
    {
        if (guess == secretNumber)
        {
            Console.WriteLine($"  Success! You guessed {guess} correctly!");
        }
        else
        {
            Console.WriteLine($"  Fail! You guessed {guess}, but the number was {secretNumber}.");
        }
    }

    // Exercise 6: Personalized Shirts
    static void Exercise6()
    {
        
        Console.Write("  ");
        MakeShirt();
        
        Console.Write("  ");
        MakeShirt("Medium");
        
        Console.Write("  ");
        MakeShirt("Small", "C# is awesome!");
        
        // Bonus: Named arguments
        Console.Write("  ");
        MakeShirt(text: "Learn C#", size: "Extra Large");
    }

    static void MakeShirt(string size = "Large", string text = "I love C#")
    {
        Console.WriteLine($"The size of the shirt is {size} and the text is '{text}'.");
    }

    // Exercise 7: Temperature Advice
    static void Exercise7()
    {
        
        Console.Write("  Enter a season (winter/spring/summer/autumn): ");
        string season = Console.ReadLine()?.ToLower() ?? "spring";
        
        int temp = GetRandomTemp(season);
        Console.WriteLine($"  Random temperature for {season}: {temp}°C");
        
        GiveTemperatureAdvice(temp);
    }

    static int GetRandomTemp(string season)
    {
        Random rnd = new Random();
        int min = -10, max = 40;

        if (season == "winter") { min = -10; max = 16; }
        else if (season == "spring") { min = 0; max = 23; }
        else if (season == "summer") { min = 16; max = 40; }
        else if (season == "autumn") { min = 0; max = 23; }

        return rnd.Next(min, max + 1);
    }

    static void GiveTemperatureAdvice(int temp)
    {
        if (temp < 0)
            Console.WriteLine("  It's freezing! Wear heavy winter clothes.");
        else if (temp < 10)
            Console.WriteLine("  It's cold. Bring a jacket.");
        else if (temp < 20)
            Console.WriteLine("  It's cool. A sweater should be fine.");
        else if (temp < 30)
            Console.WriteLine("  It's warm. Light clothing is recommended.");
        else
            Console.WriteLine("  It's hot! Wear light, breathable clothing.");
    }

    // Exercise 8: Star Wars Quiz
    static void Exercise8()
    {
        
        var data = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { {"question", "What is Baby Yoda's real name?"}, {"answer", "Grogu"} },
            new Dictionary<string, string> { {"question", "Where did Obi-Wan take Luke after his birth?"}, {"answer", "Tatooine"} },
            new Dictionary<string, string> { {"question", "What year did the first Star Wars movie come out?"}, {"answer", "1977"} },
            new Dictionary<string, string> { {"question", "Who built C-3PO?"}, {"answer", "Anakin Skywalker"} },
            new Dictionary<string, string> { {"question", "Anakin Skywalker grew up to be who?"}, {"answer", "Darth Vader"} },
            new Dictionary<string, string> { {"question", "What species is Chewbacca?"}, {"answer", "Wookiee"} }
        };

        int correct = 0;
        int incorrect = 0;
        var wrongAnswers = new List<Dictionary<string, string>>();

        foreach (var item in data)
        {
            Console.Write($"  {item["question"]} ");
            string userAnswer = Console.ReadLine() ?? "";

            if (userAnswer.Equals(item["answer"], StringComparison.OrdinalIgnoreCase))
            {
                correct++;
                Console.WriteLine("  ✓ Correct!");
            }
            else
            {
                incorrect++;
                Console.WriteLine($"  ✗ Wrong! The answer is: {item["answer"]}");
                wrongAnswers.Add(new Dictionary<string, string>
                {
                    {"question", item["question"]},
                    {"user_answer", userAnswer},
                    {"correct_answer", item["answer"]}
                });
            }
        }

        Console.WriteLine($"\n  Score: {correct} correct, {incorrect} incorrect");
        
        if (incorrect > 3)
        {
            Console.WriteLine("  Would you like to play again? (yes/no): ");
        }
    }

    // Exercise 9: Cats
    static void Exercise9()
    {
        
        Cat cat1 = new Cat("Whiskers", 3);
        Cat cat2 = new Cat("Mittens", 7);
        Cat cat3 = new Cat("Shadow", 5);
        
        var cats = new List<Cat> { cat1, cat2, cat3 };
        Cat oldestCat = FindOldestCat(cats);
        
        Console.WriteLine($"  The oldest cat is {oldestCat.CatName}, and is {oldestCat.CatAge} years old.");
    }

    static Cat FindOldestCat(List<Cat> cats)
    {
        Cat oldest = cats[0];
        foreach (var cat in cats)
        {
            if (cat.CatAge > oldest.CatAge)
                oldest = cat;
        }
        return oldest;
    }

    public class Cat
    {
        public string CatName { get; set; }
        public int CatAge { get; set; }

        public Cat(string name, int age)
        {
            CatName = name;
            CatAge = age;
        }
    }

    // Exercise 10: Dogs
    static void Exercise10()
    {
        
        Dog davidsDog = new Dog("Rex", 50);
        Dog sarahsDog = new Dog("Teacup", 20);
        
        Console.WriteLine("  David's dog:");
        davidsDog.Bark();
        davidsDog.Jump();
        
        Console.WriteLine("  Sarah's dog:");
        sarahsDog.Bark();
        sarahsDog.Jump();
        
        if (davidsDog.Height > sarahsDog.Height)
            Console.WriteLine($"  {davidsDog.DogName} is taller.");
        else if (sarahsDog.Height > davidsDog.Height)
            Console.WriteLine($"  {sarahsDog.DogName} is taller.");
        else
            Console.WriteLine("  Both dogs are the same height.");
    }

    public class Dog
    {
        public string DogName { get; set; }
        public int Height { get; set; }

        public Dog(string name, int height)
        {
            DogName = name;
            Height = height;
        }

        public void Bark()
        {
            Console.WriteLine($"    {DogName} goes woof!");
        }

        public void Jump()
        {
            Console.WriteLine($"    {DogName} jumps {Height * 2} cm high!");
        }
    }

    // Exercise 11: Who's the Song Producer?
    static void Exercise11()
    {
        
        var stairway = new Song(new List<string>{
            "There's a lady who's sure",
            "all that glitters is gold",
            "and she's buying a stairway to heaven"
        });
        
        Console.WriteLine("  Song lyrics:");
        stairway.SingMeASong();
    }

    public class Song
    {
        private List<string> lyrics;

        public Song(List<string> songLyrics)
        {
            lyrics = songLyrics;
        }

        public void SingMeASong()
        {
            foreach (var line in lyrics)
            {
                Console.WriteLine($"    {line}");
            }
        }
    }

    // Exercise 12: Afternoon at the Zoo
    static void Exercise12()
    {
        
        Zoo newYorkZoo = new Zoo("New York Zoo");
        
        Console.WriteLine("  Adding animals to the zoo...");
        newYorkZoo.AddAnimal("Lion");
        newYorkZoo.AddAnimal("Zebra");
        newYorkZoo.AddAnimal("Giraffe");
        newYorkZoo.AddAnimal("Elephant");
        newYorkZoo.AddAnimal("Bear");
        newYorkZoo.AddAnimal("Baboon");
        newYorkZoo.AddAnimal("Cougar");
        newYorkZoo.AddAnimal("Ape");
        
        Console.WriteLine("\n  All animals:");
        newYorkZoo.GetAnimals();
        
        Console.WriteLine("\n  Selling an animal...");
        newYorkZoo.SellAnimal("Zebra");
        
        Console.WriteLine("\n  Animals sorted by first letter:");
        newYorkZoo.SortAnimals();
        newYorkZoo.GetGroups();
    }

    public class Zoo
    {
        public string Name { get; set; }
        private List<string> animals;
        private Dictionary<char, List<string>> groups;

        public Zoo(string zooName)
        {
            Name = zooName;
            animals = new List<string>();
            groups = new Dictionary<char, List<string>>();
        }

        public void AddAnimal(string newAnimal)
        {
            if (!animals.Contains(newAnimal))
            {
                animals.Add(newAnimal);
                Console.WriteLine($"    {newAnimal} added to {Name}");
            }
            else
            {
                Console.WriteLine($"    {newAnimal} is already in {Name}");
            }
        }

        public void GetAnimals()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"    - {animal}");
            }
        }

        public void SellAnimal(string animalSold)
        {
            if (animals.Contains(animalSold))
            {
                animals.Remove(animalSold);
                Console.WriteLine($"    {animalSold} has been sold.");
            }
            else
            {
                Console.WriteLine($"    {animalSold} is not in the zoo.");
            }
        }

        public void SortAnimals()
        {
            groups.Clear();
            var sortedAnimals = animals.OrderBy(a => a).ToList();

            foreach (var animal in sortedAnimals)
            {
                char firstLetter = animal[0];
                if (!groups.ContainsKey(firstLetter))
                {
                    groups[firstLetter] = new List<string>();
                }
                groups[firstLetter].Add(animal);
            }

            foreach (var group in groups.OrderBy(g => g.Key))
            {
                Console.WriteLine($"    {group.Key}: [{string.Join(", ", group.Value)}]");
            }
        }

        public void GetGroups()
        {
            foreach (var group in groups.OrderBy(g => g.Key))
            {
                Console.WriteLine($"    '{group.Key}': [{string.Join(", ", group.Value)}]");
            }
        }
    }
}
