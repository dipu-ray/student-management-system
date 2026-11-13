using StudentManagement.Data;
using StudentManagement.Models;

var repo = new StudentRepository();

var s = repo.GetById(2);
Console.WriteLine(s != null ? $"Found: {s.Name}" : "Not found");

var updated = repo.Update(new Student
{
    StudentId = 2,
    Name = "Karim Uddin",
    Age = 23,
    Department = "EEE",
    Email = "karim@example.com"
});
Console.WriteLine(updated ? "Updated" : "ID not found");

foreach (var x in repo.Search("Karim"))
{
    Console.WriteLine($"{x.StudentId} | {x.Name} | {x.Age}");
}

Console.WriteLine(repo.Delete(999) ? "Deleted" : "ID 999 not found");