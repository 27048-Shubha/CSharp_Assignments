# Assignment 4: Expense Tracker

## Overview

This console application helps users manage personal finances by tracking income and expense transactions.

The application supports transaction management, reporting, and validation while demonstrating object-oriented programming principles and layered architecture.

---

## Concepts Covered

- Inheritance
- Abstraction
- Dependency Injection
- DTO (Data Transfer Object) Pattern
- Separation of Concerns
- Layered Architecture

---

## Transaction Management

- Supports both Income and Expense transactions.
- Allows users to add, view, update, and delete transactions.
- Generates unique transaction identifiers.
- Displays transaction information in a structured format.
- Validates transaction details before processing.

`Transaction` serves as the base model, while `Income` and `Expense` represent specialized transaction types.

---

## Income Management

- Supports multiple income sources.
- Records income amount and transaction date.
- CRUD operations on income data.

---

## Expense Management

- Supports multiple expense categories.
- Records expense amount and transaction date.
- CRUD operations on income data.

---

## Validation

- Prevents negative or zero transaction amounts.
- Prevents future transaction dates.
- Validates transaction identifiers.
- Handles invalid update and delete operations.

---

## DTO Implementation

- Uses DTOs to transfer data between layers.
- Separates business models from user-facing data.
- Simplifies data validation and processing.
- Reduces coupling between `Controllers` and `Services`.

### DTO Types

- `AddIncomeDto`
- `AddExpenseDto`
- `IncomeDto`
- `ExpenseDto`
- `TransactionDto`

---

## Project Structure

- **Controllers:** Coordinate application workflow and user requests.
- **Models:** Define transaction entities and DTOs.
- **Repositories:** Manage transaction storage and retrieval.
- **Services:** Implement business logic and financial operations.
- **Validators:** Validate user input and transaction rules.
- **Views:** Handle console menus and user interaction.

---

## User Navigation

- Press `1` to Add a Transaction.
- Press `2` to Manage Transactions.
- Press `3` to Exit the Application.

---

## Architecture

The application follows a layered architecture:

- **View Layer** collects user input and displays output.
- **Controller Layer** coordinates application operations.
- **Service Layer** contains business logic and validations.
- **Repository Layer** manages transaction data.
- **Model Layer** represents domain entities and DTOs.

This design promotes maintainability, testability, and scalability while keeping responsibilities clearly separated.

---

## Summary

The Expense Tracker demonstrates object-oriented programming concepts, DTO-based communication, dependency injection, repository-based data management, and layered architecture. The separation of responsibilities across controllers, services, repositories, and views makes the application easier to understand, maintain, test, and extend.