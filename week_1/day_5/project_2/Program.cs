using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static List<Transaction> transactions = new List<Transaction>();
    static string DataFile => Path.Combine(AppContext.BaseDirectory, "transactions.json");

    static void Main()
    {
        Load();
        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1": AddTransaction(); break;
                case "2": ViewTransactions(); break;
                case "3": UpdateTransaction(); break;
                case "4": DeleteTransaction(); break;
                case "5": ShowSummary(); break;
                case "6": Save(); Console.WriteLine("Saved. Exiting."); return;
                default: Console.WriteLine("Invalid option."); break;
            }
            Console.WriteLine();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("=== Personal Expense Tracker ===");
        Console.WriteLine("1. Add Transaction");
        Console.WriteLine("2. View Transactions");
        Console.WriteLine("3. Update Transaction");
        Console.WriteLine("4. Delete Transaction");
        Console.WriteLine("5. View Summary / Analysis");
        Console.WriteLine("6. Save and Exit");
        Console.Write("Choose an option: ");
    }

    static void AddTransaction()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(title)) { Console.WriteLine("Title required."); return; }

        Console.Write("Amount (use negative for expenses, positive for income): ");
        if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount)) { Console.WriteLine("Invalid amount."); return; }

        Console.Write("Category: ");
        string category = Console.ReadLine() ?? string.Empty;

        Console.Write("Date (YYYY-MM-DD) or leave blank for today: ");
        string d = Console.ReadLine() ?? string.Empty;
        DateTime date = DateTime.Now;
        if (!string.IsNullOrWhiteSpace(d))
        {
            if (!DateTime.TryParse(d, out date)) { Console.WriteLine("Invalid date format. Using today."); date = DateTime.Now; }
        }

        var t = new Transaction { Title = title.Trim(), Amount = amount, Category = category.Trim(), Date = date.Date };
        transactions.Add(t);
        Console.WriteLine($"Transaction added (ID: {t.Id}).");
    }

    static void ViewTransactions()
    {
        if (!transactions.Any()) { Console.WriteLine("No transactions recorded."); return; }
        Console.WriteLine("ID | Date | Title | Category | Amount");
        foreach (var t in transactions.OrderByDescending(x => x.Date))
        {
            if (t.Amount < 0) Console.ForegroundColor = ConsoleColor.Red; else Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(t.ToString());
            Console.ResetColor();
        }
    }

    static Transaction? FindById(Guid id) => transactions.FirstOrDefault(t => t.Id == id);

    static void UpdateTransaction()
    {
        if (!transactions.Any()) { Console.WriteLine("No transactions to update."); return; }
        ViewTransactions();
        Console.Write("Enter transaction ID to update: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id)) { Console.WriteLine("Invalid ID format."); return; }
        var t = FindById(id);
        if (t == null) { Console.WriteLine("Transaction not found."); return; }

        Console.Write($"Title ({t.Title}): ");
        string title = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(title)) t.Title = title.Trim();

        Console.Write($"Amount ({t.Amount}): ");
        string amt = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(amt) && decimal.TryParse(amt, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal a)) t.Amount = a;

        Console.Write($"Category ({t.Category}): ");
        string cat = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(cat)) t.Category = cat.Trim();

        Console.Write($"Date ({t.Date:yyyy-MM-dd}): ");
        string d = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(d) && DateTime.TryParse(d, out DateTime nd)) t.Date = nd.Date;

        Console.WriteLine("Transaction updated.");
    }

    static void DeleteTransaction()
    {
        if (!transactions.Any()) { Console.WriteLine("No transactions to delete."); return; }
        ViewTransactions();
        Console.Write("Enter transaction ID to delete: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id)) { Console.WriteLine("Invalid ID."); return; }
        var t = FindById(id);
        if (t == null) { Console.WriteLine("Transaction not found."); return; }
        Console.Write($"Confirm delete '{t.Title}' ({t.Amount})? (y/N): ");
        var ans = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
        if (ans == "y" || ans == "yes") { transactions.Remove(t); Console.WriteLine("Deleted."); } else Console.WriteLine("Cancelled.");
    }

    static void ShowSummary()
    {
        decimal totalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
        decimal totalExpense = transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);
        decimal balance = totalIncome + totalExpense;

        Console.WriteLine($"Total Income: {totalIncome:F2}");
        Console.WriteLine($"Total Expenses: {Math.Abs(totalExpense):F2}");
        Console.WriteLine($"Balance: {balance:F2}");

        var byCategory = transactions.GroupBy(t => string.IsNullOrWhiteSpace(t.Category) ? "Uncategorized" : t.Category)
                                     .Select(g => new { Category = g.Key, Total = g.Sum(x => x.Amount) })
                                     .OrderBy(x => x.Category);

        Console.WriteLine("\nTotals by Category:");
        foreach (var c in byCategory)
        {
            Console.WriteLine($"  {c.Category}: {c.Total:F2}");
        }

        Console.WriteLine("\nRecent transactions (5):");
        foreach (var t in transactions.OrderByDescending(x => x.Date).Take(5))
        {
            Console.WriteLine(t.ToString());
        }
    }

    static void Save()
    {
        try
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(DataFile, JsonSerializer.Serialize(transactions, opts));
        }
        catch (Exception ex) { Console.WriteLine($"Save error: {ex.Message}"); }
    }

    static void Load()
    {
        try
        {
            if (!File.Exists(DataFile)) return;
            var json = File.ReadAllText(DataFile);
            var loaded = JsonSerializer.Deserialize<List<Transaction>>(json);
            if (loaded != null) transactions = loaded;
        }
        catch (Exception ex) { Console.WriteLine($"Load error: {ex.Message}"); }
    }
}