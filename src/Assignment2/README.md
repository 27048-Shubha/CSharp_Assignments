# Assignment 2: Basics of OOP

## Overview

This console application demonstrates OOP concepts using three modules:

1. Shape Calculator
2. Employee Payroll System
3. Bank Account Manager

## Concepts Covered

- Inheritance
- Abstraction
- Encapsulation
- Polymorphism
- Classes and objects

## Shape Calculator

- Supports circles and rectangles.
- Accepts required dimensions from the user.
- Calculates area and perimeter.
- Validates colour input.

`Shape` is the abstract base class. `Circle` and `Rectangle` inherit from it and implement their calculations.

## Employee System

- Supports managers and developers.
- Accepts employee name and monthly salary.
- Calculates role-based bonuses where developer gets 10% of his salary as bonus, while manager gets 20% of his salary as his bonus
- Displays employee details and bonus information.

`Employee` is the abstract base class. `Manager` and `Developer` inherit from it and implement their own bonus calculations.

## Bank Account Manager

- Creates savings and checking accounts with initial balance of Rs.100 for both the accounts and minimum balance for the savings accout is Rs.100.
- Accepts account details and initial deposits.
- Supports deposits, withdrawals and balance checking.
- Displays account and transaction details.

Savings accounts prevent invalid withdrawals, while checking accounts provide flexible withdrawal behaviour.

## Project Structure

- **Controllers:** Manage application flow.
- **Models:** Define shapes, employees and accounts.
- **Repository:** Stores created objects.
- **Services:** Perform business logic and calculations.
- **Validations:** Check and validate user inputs.
- **Views:** Handle console menus and output.

## User Navigation

- Press `1` for Shape Calculator.
- Press `2` for Employee Payroll System.
- Press `3` for Bank Account Manager.
- Press `4` to exit.

## Summary

The layered design keeps each responsibility separate, making the application easier to understand, test and extend.