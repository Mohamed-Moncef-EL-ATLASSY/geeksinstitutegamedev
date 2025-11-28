using System;
using System.Collections.Generic;

public class Account
{
  public string AccountNumber { get; set; }
  public int PIN { get; set; }
  public double Balance { get; set; }
  public List<string> Transactions { get; set; }

  public Account(string accountNumber, int pin, double initialBalance)
  {
    AccountNumber = accountNumber;
    PIN = pin;
    Balance = initialBalance;
    Transactions = new List<string>();
  }

  public void CheckBalance()
  {
    Console.WriteLine($"\nCurrent Balance: ${Balance:F2}");
  }

  public bool Deposit(double amount)
  {
    if (amount <= 0)
    {
      Console.WriteLine("Deposit amount must be positive!");
      return false;
    }
    Balance += amount;
    Transactions.Add($"Deposit: +${amount:F2} (New Balance: ${Balance:F2})");
    Console.WriteLine($"Deposit successful! New balance: ${Balance:F2}");
    return true;
  }

  public bool Withdraw(double amount)
  {
    if (amount <= 0)
    {
      Console.WriteLine("Withdrawal amount must be positive!");
      return false;
    }
    if (amount > Balance)
    {
      Console.WriteLine("Insufficient funds!");
      return false;
    }
    Balance -= amount;
    Transactions.Add($"Withdrawal: -${amount:F2} (New Balance: ${Balance:F2})");
    Console.WriteLine($"Withdrawal successful! New balance: ${Balance:F2}");
    return true;
  }

  public void ShowTransactions()
  {
    if (Transactions.Count == 0)
    {
      Console.WriteLine("No transactions yet.");
      return;
    }
    Console.WriteLine("\n--- Transaction History ---");
    foreach (var transaction in Transactions)
    {
      Console.WriteLine(transaction);
    }
  }
}

public class ATM
{
  private Dictionary<string, Account> accounts;
  private Account currentAccount;

  public ATM()
  {
    accounts = new Dictionary<string, Account>();
  }

  public void AddAccount(Account account)
  {
    accounts[account.AccountNumber] = account;
  }

  public bool Authenticate()
  {
    Console.WriteLine("\n=== ATM Authentication ===");
    Console.Write("Enter account number: ");
    string accountNumber = Console.ReadLine() ?? "";

    if (!accounts.ContainsKey(accountNumber))
    {
      Console.WriteLine("Account not found!");
      return false;
    }

    Account account = accounts[accountNumber];
    int attempts = 3;

    while (attempts > 0)
    {
      Console.Write("Enter PIN: ");
      if (int.TryParse(Console.ReadLine(), out int pin))
      {
        if (pin == account.PIN)
        {
          currentAccount = account;
          Console.WriteLine("Authentication successful!\n");
          return true;
        }
      }
      attempts--;
      if (attempts > 0)
        Console.WriteLine($"Invalid PIN. {attempts} attempt(s) remaining.");
      else
        Console.WriteLine("Too many failed attempts. Access denied.");
    }
    return false;
  }

  public void ShowMenu()
  {
    Console.WriteLine("\n=== ATM Menu ===");
    Console.WriteLine("1. Check Balance");
    Console.WriteLine("2. Deposit Money");
    Console.WriteLine("3. Withdraw Money");
    Console.WriteLine("4. Show Transactions");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");
  }

  public void PerformAction(string choice)
  {
    switch (choice)
    {
      case "1":
        currentAccount.CheckBalance();
        break;
      case "2":
        Console.Write("Enter deposit amount: $");
        if (double.TryParse(Console.ReadLine(), out double depositAmount))
          currentAccount.Deposit(depositAmount);
        else
          Console.WriteLine("Invalid amount!");
        break;
      case "3":
        Console.Write("Enter withdrawal amount: $");
        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
          currentAccount.Withdraw(withdrawAmount);
        else
          Console.WriteLine("Invalid amount!");
        break;
      case "4":
        currentAccount.ShowTransactions();
        break;
      case "5":
        return;
      default:
        Console.WriteLine("Invalid option! Please try again.");
        break;
    }
  }

  public Account GetCurrentAccount()
  {
    return currentAccount;
  }
}

class Program
{
  static void Main()
  {
    ATM atm = new ATM();

    atm.AddAccount(new Account("12345", 6789, 1000));
    atm.AddAccount(new Account("54321", 9876, 2500));
    atm.AddAccount(new Account("11111", 1111, 500));

    Console.WriteLine("=== Welcome to the ATM Machine ===");

    bool continueUsing = true;
    while (continueUsing)
    {
      if (atm.Authenticate())
      {
        bool exitAccount = false;
        while (!exitAccount)
        {
          atm.ShowMenu();
          string choice = Console.ReadLine() ?? "";

          if (choice == "5")
          {
            exitAccount = true;
            PrintSummary(atm.GetCurrentAccount());
          }
          else
          {
            atm.PerformAction(choice);
          }
        }

        Console.Write("\nUse ATM again? (yes/no): ");
        string response = Console.ReadLine()?.ToLower() ?? "no";
        if (response != "yes")
          continueUsing = false;
      }
      else
      {
        Console.Write("\nTry again? (yes/no): ");
        string response = Console.ReadLine()?.ToLower() ?? "no";
        if (response != "yes")
          continueUsing = false;
      }
    }

    Console.WriteLine("\nThank you for using our ATM. Goodbye!");
  }

  static void PrintSummary(Account account)
  {
    Console.WriteLine("\n=== Transaction Summary ===");
    Console.WriteLine($"Account: {account.AccountNumber}");
    Console.WriteLine($"Final Balance: ${account.Balance:F2}");
    Console.WriteLine("\nTransactions:");

    if (account.Transactions.Count == 0)
    {
      Console.WriteLine("No transactions performed.");
    }
    else
    {
      foreach (var transaction in account.Transactions)
      {
        Console.WriteLine(transaction);
      }
    }
  }
}