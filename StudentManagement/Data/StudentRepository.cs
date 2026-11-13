using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class StudentRepository
    {
        private readonly string _connectionString =
            @"Server=localhost\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Add(Student student)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@Department", student.Department);
            cmd.Parameters.AddWithValue("@Email", student.Email);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllStudents", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    StudentId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Age = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                    Department = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    CreatedAt = reader.GetDateTime(5)
                });
            }

            return students;
        }
    }
}