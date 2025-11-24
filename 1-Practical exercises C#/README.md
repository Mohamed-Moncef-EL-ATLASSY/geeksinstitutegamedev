# C# Practical Exercises

A collection of 7 beginner-friendly C# exercises covering fundamental programming concepts.

## Exercises Overview

Here are 7 beginner exercises to test your new C# skills. Try to solve them in Visual Studio or an online compiler!

### Exercise 1: The Greeting Task
- **Task**: Write a program that prints "Welcome to C# Programming!" to the console.
- **Goal**: Understand basic output syntax.

### Exercise 2: Personal Info Task
- **Task**: Create two variables: `name` (set it to your name) and `int age` (set it to your age). Print a sentence combining them, e.g., "My name is Sam and I am 25 years old."
- **Goal**: Understand variables and string concatenation.

### Exercise 3: The Calculator Task
- **Task**: Create two integer variables, `num1` and `num2`. Create a third variable `sum` that adds them together. Print the result.
- **Goal**: Basic arithmetic operators.

### Exercise 4: The Bouncer (If/Else) Task
- **Task**: Create a variable `int userAge`. Write an if statement that checks:
  - If age is 18 or older, print "Access Granted."
  - If age is less than 18, print "Access Denied."
- **Goal**: Conditional logic.

### Exercise 5: The Countdown (Loops) Task
- **Task**: Write a while loop that prints numbers starting from 10 down to 1. After the loop finishes, print "Liftoff!"
- **Goal**: Understanding loop iteration and decrementing.

### Exercise 6: The Repeater (Functions) Task
- **Task**: Create a function called `SayHello` that takes a `string name` as a parameter. When called, it should print "Hello, [name]!". Call this function three times with different names.
- **Goal**: Defining and calling methods with parameters.

### Exercise 7: Even or Odd?
- **Task**: Write a program that loops through numbers 1 to 10. Inside the loop, check if the current number is even or odd. Print "Number X is Even" or "Number X is Odd".
- **Hint**: Use the modulus operator `%`. If `number % 2 == 0`, it is even.
- **Goal**: Combining loops and if/else logic.

### Run a Single Exercise

```bash
dotnet run --project Exercise1
dotnet run --project Exercise2
dotnet run --project Exercise3
dotnet run --project Exercise4
dotnet run --project Exercise5
dotnet run --project Exercise6
dotnet run --project Exercise7
```

### Run All Exercises

```bash
for i in {1..7}; do
    echo "=== Exercise $i ==="
    dotnet run --project "Exercise$i"
    echo ""
done
```
