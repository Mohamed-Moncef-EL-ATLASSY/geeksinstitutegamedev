using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static string DataFile => Path.Combine(AppContext.BaseDirectory, "tasks.json");
    static List<TaskItem> tasks = new List<TaskItem>();

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
                case "1": AddTask(); break;
                case "2": ViewTasks(); break;
                case "3": UpdateTaskStatus(); break;
                case "4": DeleteTask(); break;
                case "5": SearchTasks(); break;
                case "6": Save(); Console.WriteLine("Saved. Exiting."); return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
            Console.WriteLine();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("=== Personal Task Manager ===");
        Console.WriteLine("1. Add a Task");
        Console.WriteLine("2. View Tasks");
        Console.WriteLine("3. Update Task Status");
        Console.WriteLine("4. Delete a Task");
        Console.WriteLine("5. Search Tasks");
        Console.WriteLine("6. Save and Exit");
        Console.Write("Choose an option: ");
    }

    static void AddTask()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(title)) { Console.WriteLine("Title cannot be empty."); return; }

        Console.Write("Description: ");
        string desc = Console.ReadLine() ?? string.Empty;

        Console.Write("Due date (YYYY-MM-DD or leave blank): ");
        string dateInput = Console.ReadLine() ?? string.Empty;
        DateTime? due = null;
        if (!string.IsNullOrWhiteSpace(dateInput))
        {
            if (DateTime.TryParse(dateInput, out DateTime dt)) due = dt.Date;
            else { Console.WriteLine("Invalid date format. Skipping due date."); }
        }

        var t = new TaskItem { Title = title.Trim(), Description = desc.Trim(), DueDate = due };
        tasks.Add(t);
        Console.WriteLine("Task added.");
    }

    static void ViewTasks()
    {
        if (!tasks.Any()) { Console.WriteLine("No tasks found."); return; }
        for (int i = 0; i < tasks.Count; i++)
        {
            var t = tasks[i];
            Console.WriteLine($"{i + 1}. {t}");
        }
    }

    static void UpdateTaskStatus()
    {
        if (!tasks.Any()) { Console.WriteLine("No tasks to update."); return; }
        ViewTasks();
        Console.Write("Select task number to toggle status: ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > tasks.Count) { Console.WriteLine("Invalid selection."); return; }
        var task = tasks[idx - 1];
        task.Status = task.Status == TaskStatus.Pending ? TaskStatus.Completed : TaskStatus.Pending;
        Console.WriteLine($"Task '{task.Title}' status changed to {task.Status}.");
    }

    static void DeleteTask()
    {
        if (!tasks.Any()) { Console.WriteLine("No tasks to delete."); return; }
        ViewTasks();
        Console.Write("Select task number to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > tasks.Count) { Console.WriteLine("Invalid selection."); return; }
        var task = tasks[idx - 1];
        Console.Write($"Are you sure you want to delete '{task.Title}'? (y/N): ");
        var ans = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
        if (ans == "y" || ans == "yes")
        {
            tasks.RemoveAt(idx - 1);
            Console.WriteLine("Task deleted.");
        }
        else Console.WriteLine("Delete cancelled.");
    }

    static void SearchTasks()
    {
        Console.Write("Search keyword: ");
        string kw = (Console.ReadLine() ?? string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(kw)) { Console.WriteLine("Empty keyword."); return; }
        var results = tasks.Where(t => t.Title.Contains(kw, StringComparison.OrdinalIgnoreCase) || t.Description.Contains(kw, StringComparison.OrdinalIgnoreCase)).ToList();
        if (!results.Any()) { Console.WriteLine("No matching tasks."); return; }
        Console.WriteLine($"Found {results.Count} matching tasks:");
        foreach (var t in results) Console.WriteLine(t);
    }

    static void Save()
    {
        try
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(tasks, opts);
            File.WriteAllText(DataFile, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving tasks: {ex.Message}");
        }
    }

    static void Load()
    {
        try
        {
            if (!File.Exists(DataFile)) return;
            var json = File.ReadAllText(DataFile);
            var loaded = JsonSerializer.Deserialize<List<TaskItem>>(json);
            if (loaded != null) tasks = loaded;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tasks: {ex.Message}");
        }
    }
}