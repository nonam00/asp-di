namespace DI.Models;

public class Employee : Person
{
    public string Job { get; set; } = null!;
    public decimal Salary { get; set; }
}