# Library Management System - C# Console App

This is a simple console-based Library Management System built using C# and .NET Core. It allows Admin and Guest users to interact with a digital book library.

---

## Features

- Role-based Access:
  - Admin: Add and view books
  - Guest: View books only

- Book Operations:
  - Add new books (Admin only)
  - View all books
  - Search books by title (standard & LINQ)
  - Filter books by category using LINQ
  - Sort books by title or author

- Data Persistence:
  - Save and load books to/from a JSON file
  - Supports both sync and async operations

---

## Technologies Used

- C#
- .NET Core
- Console App
- JSON Serialization (`System.Text.Json`)
- LINQ
- Async/Await
- OOP Principles

---

## Project Structure

- `Book.cs` – Represents a book entity
- `Library.cs` – Manages book operations
- `User.cs` – Abstract user class
- `AdminUser.cs` and `GuestUser.cs` – Role-based classes
- `Program.cs` – Entry point with UI logic
- `books.json` – File for saving/loading books

---

## Concepts Covered

- OOP (Inheritance, Abstraction, Polymorphism)
- Interfaces
- Enums
- LINQ
- File handling (JSON)
- Asynchronous programming
- Console application development

---

## How to Run

1. Clone or download this repository.
2. Open the project in **Visual Studio** or run it using the **.NET CLI**.
3. Build and run the application.
4. Choose user type and interact via console menu.

---

## Future Improvements

- Add user authentication
- Enable editing/deleting books
- Add unit tests
- Convert to ASP.NET Core Web API for frontend integration

---

