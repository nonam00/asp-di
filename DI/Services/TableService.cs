using DI.Models;

namespace DI.Services;

public class TableService
{
    public string GetString(Person person)
    {
        var result = $"<tr><td>{person.Name}</td><td>{person.DateOfBirth:dd/MM/yyyy}</td>";
        if (person is Employee employee)
        {
            result += $"<td>{employee.Job}</td><td>{employee.Salary}</td></tr>";
        }
        result += "</tr>";
        return result;
    }
}