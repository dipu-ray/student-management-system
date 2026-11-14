<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:0F2027,50:203A43,100:2C5364&height=220&section=header&text=Student%20Management%20System&fontSize=44&fontColor=ffffff&animation=fadeIn&fontAlignY=38&desc=C%23%20%7C%20.NET%20%7C%20SQL%20Server%20%7C%20Stored%20Procedures&descAlignY=58&descSize=18" alt="Student Management System banner" />

<a href="https://git.io/typing-svg">
  <img src="https://readme-typing-svg.demolab.com?font=Fira+Code&weight=600&size=22&pause=1000&color=36BCF7&center=true&vCenter=true&width=640&lines=%F0%9F%8E%93+Manage+student+records+with+ease;%E2%9A%A1+Fast+console-based+CRUD+application;%F0%9F%97%84%EF%B8%8F+Powered+by+SQL+Server+%26+Stored+Procedures;%F0%9F%9B%A1%EF%B8%8F+Input+validation+%26+safe+error+handling" alt="Typing animation" />
</a>

<br/>

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)

![Status](https://img.shields.io/badge/status-active-success?style=flat-square)
![Version](https://img.shields.io/badge/version-1.0.0-blue?style=flat-square)
![Platform](https://img.shields.io/badge/platform-Windows-0078D6?style=flat-square&logo=windows&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)

![Started](https://img.shields.io/github/created-at/dipu-ray/student-management-system?style=flat-square&label=started&color=blueviolet)
![Last Update](https://img.shields.io/github/last-commit/dipu-ray/student-management-system?style=flat-square&label=last%20update&color=orange)

</div>

---

## 📖 Table of Contents

- [About the Project](#-about-the-project)
- [Project Timeline](#️-project-timeline)
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Architecture](#-architecture)
- [Project Structure](#-project-structure)
- [Database Design](#-database-design)
- [Getting Started](#-getting-started)
- [Usage](#-usage)
- [Validation & Error Handling](#-validation--error-handling)
- [What I Learned](#-what-i-learned)
- [Roadmap](#-roadmap)
- [Contributing](#-contributing)
- [Author](#-author)

---

## 🎯 About the Project

**Student Management System** is a console-based CRUD application built with **C#** and **SQL Server**. It lets you add, view, update, delete, and search student records, with all data stored permanently in a SQL Server database.

All database logic lives in **stored procedures**, and C# talks to them through **ADO.NET** using parameterized commands, which keeps the code clean and protects against SQL Injection.

> 💡 This project was built to practice the full path from C# fundamentals and SQL to a working, database-driven application.

---

## 🗓️ Project Timeline

|     | Milestone           | Date             |
| --- | ------------------- | ---------------- |
| 🚀  | **Started**         | 7 November 2026  |
| 🔄  | **Last Updated**    | 14 November 2026 |
| 📌  | **Current Version** | v1.0.0           |

> The **Started** and **Last update** badges at the top of this page update automatically from GitHub.

---

## ✨ Features

|     | Feature               | Description                                           |
| --- | --------------------- | ----------------------------------------------------- |
| ➕  | **Add Student**       | Save name, age, department and email                  |
| 📋  | **View All Students** | Display every record in a neat table                  |
| ✏️  | **Update Student**    | Edit a record by ID, with current values shown first  |
| 🗑️  | **Delete Student**    | Remove a record by ID with a **Y/N confirmation**     |
| 🔍  | **Search Student**    | Find students by full or partial name                 |
| ✅  | **Input Validation**  | Blocks empty, invalid, or out-of-range input          |
| 🛡️  | **Error Handling**    | Database errors never crash the app                   |
| 🔒  | **Secure Queries**    | Parameterized stored procedures prevent SQL Injection |

---

## 🧰 Tech Stack

| Layer           | Technology                           |
| --------------- | ------------------------------------ |
| Language        | C#                                   |
| Framework       | .NET (console app)                   |
| Database        | Microsoft SQL Server (Express)       |
| Data Access     | ADO.NET (`Microsoft.Data.SqlClient`) |
| Database Tool   | SQL Server Management Studio (SSMS)  |
| Version Control | Git & GitHub                         |

---

## 🏗️ Architecture

The app is split into small layers, each with one responsibility:

```mermaid
flowchart LR
    A[👤 User] --> B[🖥️ Console UI<br/>Menu.cs]
    B --> C[📦 Repository<br/>StudentRepository.cs]
    C --> D[🔌 ADO.NET<br/>SqlConnection / SqlCommand]
    D --> E[⚙️ Stored Procedures]
    E --> F[(🗄️ SQL Server<br/>StudentDB)]
```

| Layer           | File                        | Responsibility                       |
| --------------- | --------------------------- | ------------------------------------ |
| **UI**          | `UI/Menu.cs`                | Menu, user input, validation, output |
| **Data Access** | `Data/StudentRepository.cs` | Calls stored procedures via ADO.NET  |
| **Model**       | `Models/Student.cs`         | Represents one student               |
| **Database**    | `Database/setup.sql`        | Tables and stored procedures         |

---

## 📂 Project Structure

```
student-management-system/
├── 📁 Database/
│   └── 📄 setup.sql              # Database, table & stored procedures
├── 📁 StudentManagement/
│   ├── 📁 Models/
│   │   └── 📄 Student.cs         # Student model
│   ├── 📁 Data/
│   │   └── 📄 StudentRepository.cs   # CRUD operations (ADO.NET)
│   ├── 📁 UI/
│   │   └── 📄 Menu.cs            # Console menu & validation
│   ├── 📄 Program.cs             # Entry point
│   └── 📄 StudentManagement.csproj
├── 📄 .gitignore
└── 📄 README.md
```

---

## 🗄️ Database Design

### `Students` table

| Column       | Type            | Constraints                |
| ------------ | --------------- | -------------------------- |
| `StudentId`  | `INT`           | Primary Key, Identity(1,1) |
| `Name`       | `NVARCHAR(100)` | NOT NULL                   |
| `Age`        | `INT`           |                            |
| `Department` | `NVARCHAR(50)`  |                            |
| `Email`      | `NVARCHAR(100)` | UNIQUE                     |
| `CreatedAt`  | `DATETIME`      | Default `GETDATE()`        |

### Stored procedures

| Procedure           | Purpose                          |
| ------------------- | -------------------------------- |
| `sp_AddStudent`     | Insert a new student             |
| `sp_GetAllStudents` | Return all students              |
| `sp_GetStudentById` | Return one student by ID         |
| `sp_UpdateStudent`  | Update a student by ID           |
| `sp_DeleteStudent`  | Delete a student by ID           |
| `sp_SearchStudent`  | Search students by name (`LIKE`) |

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later)
- [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms)
- [Git](https://git-scm.com/)

### Installation

**1. Clone the repository**

```bash
git clone https://github.com/YOUR_USERNAME/student-management-system.git
cd student-management-system
```

**2. Set up the database**

Open `Database/setup.sql` in SSMS and click **Execute**. This creates the `StudentDB` database, the `Students` table, and all stored procedures.

**3. Configure the connection string**

Open `StudentManagement/Data/StudentRepository.cs` and set your own SQL Server name:

```csharp
private readonly string _connectionString =
    @"Server=localhost\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;";
```

> 🔎 Use the same **Server name** you see when connecting in SSMS (for example `localhost\SQLEXPRESS` or `(localdb)\MSSQLLocalDB`).

**4. Run the application**

```bash
cd StudentManagement
dotnet run
```

---

## 🖥️ Usage

When the app starts you will see this menu:

```
=== Student Management System ===
1. Add Student
2. View All Students
3. Update Student
4. Delete Student
5. Search Student
6. Exit
Choose an option:
```

**Example: viewing all students**

```
--- All Students ---
ID   Name                  Age   Dept        Email
----------------------------------------------------------------------
1    Karim Uddin           23    EEE         karim@example.com
2    Rahim Ahmed           21    CSE         rahim@example.com
```

---

## 🛡️ Validation & Error Handling

| Check                             | Behavior                                  |
| --------------------------------- | ----------------------------------------- |
| Empty name or department          | Asks again until a value is entered       |
| Age not a number or outside 5-100 | Asks again                                |
| Email without `@` or `.`          | Asks again                                |
| ID does not exist                 | Shows a clear "not found" message         |
| Delete                            | Asks for **Y/N** confirmation first       |
| Duplicate email                   | Caught by `try-catch`, app keeps running  |
| Database unreachable              | Friendly error message instead of a crash |

---

## 📚 What I Learned

- ✅ C# fundamentals: variables, conditions, loops, methods, classes
- ✅ Designing tables with constraints (PK, UNIQUE, NOT NULL, DEFAULT)
- ✅ Writing and calling **stored procedures** with parameters
- ✅ Connecting C# to SQL Server using **ADO.NET**
- ✅ Preventing **SQL Injection** with parameterized commands
- ✅ Structuring code into layers (UI, Data, Model)
- ✅ Exception handling with `try-catch`
- ✅ Using **Git & GitHub** for version control

---

## 🗺️ Roadmap

- [x] CRUD operations with stored procedures
- [x] Console menu with validation
- [x] Error handling and delete confirmation

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome.

1. Fork the project
2. Create your branch: `git checkout -b feature/amazing-feature`
3. Commit your changes: `git commit -m "Add amazing feature"`
4. Push the branch: `git push origin feature/amazing-feature`
5. Open a Pull Request

---

## 👤 Author

**Your Name**

[![GitHub](https://img.shields.io/badge/GitHub-DIPU_RAY-181717?style=for-the-badge&logo=github)](https://github.com/dipu-ray)

---

<div align="center">

⭐ **If you found this project helpful, please give it a star!** ⭐

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:2C5364,50:203A43,100:0F2027&height=120&section=footer" alt="Footer wave" />

</div>
