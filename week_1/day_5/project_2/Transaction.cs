using System;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;

    public override string ToString()
    {
        string sign = Amount < 0 ? "-" : "+";
        return $"{Id} | {Date:yyyy-MM-dd} | {Title} | {Category} | {sign}{Math.Abs(Amount):F2}";
    }
}