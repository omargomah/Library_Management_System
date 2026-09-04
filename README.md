<div align="center">
  <h1>📚 Library Management System</h1>
  <p><i>A robust, enterprise-grade Console Application for managing library operations.</i></p>
  
  <!-- Shields / Badges -->
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET Core" />
  <img src="https://img.shields.io/badge/Entity%20Framework-339933?style=for-the-badge&logo=entity-framework&logoColor=white" alt="EF Core" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
</div>

<br/>

## 📖 Project Overview
This project is a comprehensive Library Management System built as a C# Console Application. It allows librarians and administrators to seamlessly manage books, categories, members, and borrowing operations. 
---

## 🚀 Key Features

### 🗄️ Core Management Modules
*   **Book Management:** Add, update, delete, and retrieve book records. Includes advanced LINQ filtering to search by Title, filter by Price and Published Year, and sort ascending/descending.
*   **Category Management:** Manage book categories and view all books belonging to a specific category.
*   **Member Management:** Register and manage library members, including viewing a member's complete borrowing history[cite: 1].
*   **Borrowing Management:** Securely handle checking out and returning books. The system enforces business rules to ensure a book is available, the member exists, and that an already returned book cannot be returned again[cite: 1].

### 📊 Advanced Reports & Analytics
The system uses powerful LINQ aggregate functions (`GroupBy`, `Count`, `Average`, `OrderByDescending`) to generate insights[cite: 1]:
*   **Most Borrowed Books:** Displays books ordered by the number of times they have been borrowed[cite: 1].
*   **Most Active Members:** Displays members ordered by the number of books they have borrowed[cite: 1].
*   **Books Per Category:** Displays the number of books in each category[cite: 1].
*   **Financial Insight:** Calculates the average price of all library books[cite: 1].

### 🎯 Challenge Implementations
This project successfully implements advanced business logic requirements[cite: 1]:
*   **Maximum Borrowing Limits:** Members are restricted from borrowing more than 10 books at a single time. 
*   **Late-Return Calculations & Fines:** Automatically calculates late days based on a 14-day borrowing policy and applies a $5/day fine upon return[cite: 1].
*   **Most Popular Category Analysis:** Dynamically calculates which category has the highest user demand based on historical borrow counts[cite: 1].

---

## 🏗️ Architecture & Database Design

### Tech Stack
*   **Language:** C#[cite: 1]
*   **Paradigms:** Object-Oriented Programming (OOP)[cite: 1]
*   **Data Access:** Entity Framework Core, LINQ, Collections[cite: 1]
*   **Database:** SQL Server[cite: 1]
*   **Version Control:** Git & GitHub

### Database Schema (ERD)
The system models relational data using the following entities[cite: 1]:
*   **`Category`**: Contains `Id` and `Name`[cite: 1]. One Category can contain multiple Books[cite: 1].
*   **`Book`**: Contains `Id`, `Title`, `Author`, `Price`, `PublishedYear`, and `CategoryId`[cite: 1]. A Book belongs to one Category[cite: 1].
*   **`Member`**: Contains `Id`, `Name`, `Email`, and `Phone`[cite: 1]. A Member can have multiple borrowing operations[cite: 1].
*   **`Borrowing`**: Contains `Id`, `BookId`, `MemberId`, `BorrowDate`, and `ReturnDate`[cite: 1]. A Borrowing belongs to one Book and one Member[cite: 1].

---

## ⚙️ Getting Started

### Prerequisites
*   [.NET 10.0+ SDK](https://dotnet.microsoft.com/download)
*   [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)
*   Visual Studio or VS Code

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/omargomah/Library_Management_System.git](https://github.com/omargomah/Library_Management_System.git)
   cd Library_Management_System
Configure the Database Connection:
Open the appsettings.json file and update the ConnectionStrings section to point to your local SQL Server instance[cite: 1].

JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
Apply EF Core Migrations:
The project includes a robust set of seed data (10 categories, 20 members, 50 books, and 100 historical borrowings). Run the following command in the Package Manager Console to create the database and insert the seed data[cite: 1]:

PowerShell
Update-Database
Run the Application:
Start the console application to interact with the main menu[cite: 1].

💻 Usage Example
Upon starting the application, you will be greeted with an interactive console menu[cite: 1]:

Plaintext
=================================
===== Library Management System =====
=================================
1. Book Management
2. Category Management
3. Member Management
4. Borrowing Management
5. Reports
6. Exit

Select an option: 
The console interface includes robust data validation to ensure the application does not crash due to invalid inputs (e.g., invalid IDs, non-existing records, or formatting errors)[cite: 1]. All operations return the user to the appropriate menu after execution[cite: 1].
