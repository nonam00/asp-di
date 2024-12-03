using System.Text;
using DI.Models;
using DI.Services;
using Microsoft.AspNetCore.Mvc;

List<Person> people =
[
    new()
    {
        Name = "John Doe",
        DateOfBirth = new DateTime(1999, 12, 25)
    },
    new()
    {
        Name = "Jane Doe",
        DateOfBirth = new DateTime(2001, 4, 21)
    }
];

List<Employee> employees =
[
    new()
    {
        Name = "Denis Herbert",
        DateOfBirth = new DateTime(1990, 12, 9),
        Job = "Manager",
        Salary = 1500
    },
    new()
    {
        Name = "Pal Remington",
        DateOfBirth = new DateTime(2003, 5, 12),
        Job = "Manager",
        Salary = 1700
    },
];

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TableService>();

var app = builder.Build();

app.MapGet("/persons", async (HttpContext context, [FromServices]TableService tableService) =>
{
    var sb = new StringBuilder();
    sb.AppendLine("<table><tr><td>Name</td><td>Birth Date</td></tr>");
    foreach (var person in people)
    {
        sb.Append(tableService.GetString(person));
    }
    sb.AppendLine("</table>");
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(sb.ToString());
});

app.MapGet("/persons/{name}", async (HttpContext context, string name, [FromServices]TableService tableService) =>
{
    var sb = new StringBuilder();
    sb.AppendLine("<table><tr><td>Name</td><td>Birth Date</td></tr>");
    var persons = people.Where(p => p.Name == name);
    foreach (var person in persons)
    {
        sb.Append(tableService.GetString(person));
    }
    sb.AppendLine("</table>");
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(sb.ToString());   
});

app.MapGet("/employees", async (HttpContext context, [FromServices]TableService tableService) =>
{
    var sb = new StringBuilder();
    sb.AppendLine("<table><tr><td>Name</td><td>Birth Date</td><td>Job</td><td>Salary</td></tr>");
    foreach (var employee in employees)
    {
        sb.Append(tableService.GetString(employee));
    }
    sb.AppendLine("</table>");
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(sb.ToString());
});

app.MapGet("/employees/{name}", async (HttpContext context, string name, [FromServices]TableService tableService) =>
{
    var sb = new StringBuilder();   
    sb.AppendLine("<table><tr><td>Name</td><td>Birth Date</td><td>Job</td><td>Salary</td></tr>");
    var empls = employees.Where(p => p.Name == name);
    foreach (var person in empls)
    {
        sb.Append(tableService.GetString(person));
    }
    sb.AppendLine("</table>");
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(sb.ToString());   
});

app.Run();