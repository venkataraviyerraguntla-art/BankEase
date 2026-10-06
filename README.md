# BankEase - Banking Management System

BankEase is a simple Banking Management System developed using ASP.NET MVC, C#, Entity Framework Code First, and SQL Server.

The application allows users to manage customers, bank accounts, deposits, withdrawals, and transaction history.

## Features

- Customer Management
  - Add new customers
  - View customer details
  - Edit customer information
  - Delete customers

- Account Management
  - Create bank accounts
  - View account details
  - Edit account information
  - Delete accounts
  - Link accounts with customers

- Banking Transactions
  - Deposit money
  - Withdraw money
  - Check available balance
  - Prevent withdrawal when balance is insufficient

- Transaction History
  - View deposit and withdrawal transactions
  - Display account number, transaction type, amount, and transaction date

## Technologies Used

- C#
- ASP.NET MVC 5
- Entity Framework 6
- Entity Framework Code First
- SQL Server
- HTML
- CSS
- Bootstrap
- Visual Studio

## Database

The project uses SQL Server with Entity Framework Code First.

Database name:

`BankEaseDB`

Connection string name:

`Constr`

## Project Structure

```text
BankEase
│
├── Models
│   ├── Customer.cs
│   ├── Account.cs
│   ├── BankTransaction.cs
│   └── BankContext.cs
│
├── Controllers
│   ├── CustomerController.cs
│   ├── AccountController.cs
│   ├── BankTransactionController.cs
│   └── HomeController.cs
│
└── Views
    ├── Customer
    ├── Account
    ├── BankTransaction
    ├── Home
    └── Shared
