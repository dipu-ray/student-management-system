using StudentManagement.Data;
using StudentManagement.Models;

var repo = new StudentRepository();

repo.Add(new Student
{
    Name = "Karim",
    Age = 22,
    Department = "EEE",
    Email = "karim@example.com"
});

foreach (var s in repo.GetAll())
{
    Console.WriteLine($"{s.StudentId} | {s.Name} | {s.Age} | {s.Department} | {s.Email}");
}