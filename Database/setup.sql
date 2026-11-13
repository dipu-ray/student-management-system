CREATE DATABASE StudentDB;
GO

USE StudentDB;
GO

CREATE TABLE Students (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Age INT,
    Department NVARCHAR(50),
    Email NVARCHAR(100) UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE PROCEDURE sp_AddStudent
    @Name NVARCHAR(100),
    @Age INT,
    @Department NVARCHAR(50),
    @Email NVARCHAR(100)
AS
BEGIN
    INSERT INTO Students (Name, Age, Department, Email)
    VALUES (@Name, @Age, @Department, @Email);
END
GO

CREATE PROCEDURE sp_GetAllStudents
AS
BEGIN
    SELECT StudentId, Name, Age, Department, Email, CreatedAt
    FROM Students
    ORDER BY StudentId;
END
GO

CREATE PROCEDURE sp_GetStudentById
    @StudentId INT
AS
BEGIN
    SELECT StudentId, Name, Age, Department, Email, CreatedAt
    FROM Students
    WHERE StudentId = @StudentId;
END
GO

CREATE PROCEDURE sp_UpdateStudent
    @StudentId INT,
    @Name NVARCHAR(100),
    @Age INT,
    @Department NVARCHAR(50),
    @Email NVARCHAR(100)
AS
BEGIN
    UPDATE Students
    SET Name = @Name,
        Age = @Age,
        Department = @Department,
        Email = @Email
    WHERE StudentId = @StudentId;
END
GO

CREATE PROCEDURE sp_DeleteStudent
    @StudentId INT
AS
BEGIN
    DELETE FROM Students
    WHERE StudentId = @StudentId;
END
GO

CREATE PROCEDURE sp_SearchStudent
    @Name NVARCHAR(100)
AS
BEGIN
    SELECT StudentId, Name, Age, Department, Email, CreatedAt
    FROM Students
    WHERE Name LIKE '%' + @Name + '%';
END
GO