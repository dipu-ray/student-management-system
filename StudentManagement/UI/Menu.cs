using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.UI
{
    public class Menu
    {
        private readonly StudentRepository _repo = new StudentRepository();

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1": AddStudent(); break;
                        case "2": ViewAll(); break;
                        case "3": UpdateStudent(); break;
                        case "4": DeleteStudent(); break;
                        case "5": SearchStudent(); break;
                        case "6":
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please choose 1 to 6.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Student Management System ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Search Student");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
        }

        private void AddStudent()
        {
            Console.WriteLine("\n--- Add Student ---");
            var student = ReadStudentInfo();
            _repo.Add(student);
            Console.WriteLine("Student added successfully.");
        }

        private void ViewAll()
        {
            Console.WriteLine("\n--- All Students ---");
            PrintStudents(_repo.GetAll());
        }

        private void UpdateStudent()
        {
            Console.WriteLine("\n--- Update Student ---");
            int id = ReadInt("Student ID: ", 1, int.MaxValue);

            var existing = _repo.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("No student found with the given ID.");
                return;
            }

            Console.WriteLine($"Current: {existing.Name} | {existing.Age} | {existing.Department} | {existing.Email}");
            var student = ReadStudentInfo();
            student.StudentId = id;

            Console.WriteLine(_repo.Update(student) ? "Student updated successfully." : "Update failed.");
        }

        private void DeleteStudent()
        {
            Console.WriteLine("\n--- Delete Student ---");
            int id = ReadInt("Student ID: ", 1, int.MaxValue);

            var existing = _repo.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("No student found with the given ID.");
                return;
            }

            Console.Write($"Are you sure you want to delete '{existing.Name}'? (Y/N): ");
            string confirm = Console.ReadLine()?.Trim().ToUpper() ?? "";

            if (confirm == "Y")
                Console.WriteLine(_repo.Delete(id) ? "Student deleted." : "Delete failed.");
            else
                Console.WriteLine("Delete cancelled.");
        }

        private void SearchStudent()
        {
            Console.WriteLine("\n--- Search Student ---");
            string name = ReadRequiredText("Name (or part of the name): ");
            PrintStudents(_repo.Search(name));
        }

        // ---------- Input helper ----------

        private Student ReadStudentInfo()
        {
            return new Student
            {
                Name = ReadRequiredText("Name: "),
                Age = ReadInt("Age (5-100): ", 5, 100),
                Department = ReadRequiredText("Department: "),
                Email = ReadEmail("Email: ")
            };
        }

        private string ReadRequiredText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(input)) return input;
                Console.WriteLine("This field is required.");
            }
        }

        private int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Please enter a number between {min} and {max}.");
            }
        }

        private string ReadEmail(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? "";
                if (input.Contains('@') && input.Contains('.')) return input;
                Console.WriteLine("Please enter a valid email address (e.g., name@example.com).");
            }
        }

        private void PrintStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No student found.");
                return;
            }

            Console.WriteLine($"{"ID",-5}{"Name",-22}{"Age",-6}{"Dept",-12}{"Email"}");
            Console.WriteLine(new string('-', 70));

            foreach (var s in students)
            {
                Console.WriteLine($"{s.StudentId,-5}{s.Name,-22}{s.Age,-6}{s.Department,-12}{s.Email}");
            }
        }
    }
}