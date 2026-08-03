# Assignment 3 - Inventory Management

## Overview

- This is a Console-based **Inventory Management System** following the **MVC (Model-View-Controller)** architecture. 
- This inventory management supports CRUD operations, Sort feature and included Exception Handling & Enums.

## Features

- Add a product
- View all products
- Search products by name
- Edit product details
- Delete a product
- Sort products - by name, price, stock quantity
- Input validation
- Exception handling for Name not found and Inventory empty cases.

## MVC Architecture

### Model

Contains the data model.

- **Product.cs** – Represents a product in the inventory.

### View

Responsible for interacting with the user through the console.

- **ConsoleView.cs** – Displays menus, reads input, and prints results in respective console colors.

### Controller

Acts as the bridge between the View and the Service layer.

- **InventoryController.cs** – Receives user requests and invokes the appropriate service methods.

### Service

Contains the business logic of the application.

- **InventoryService.cs** – Performs validation and inventory operations before interacting with the repository.

### Repository

Handles data storage and retrieval.

- **IProductRepository.cs** – Repository interface (contract).
- **ProductRepository.cs** – Manages the in-memory list of products.

### Enums

Stores menu choices for better readability and maintainability, instead of direct usage of numerics/options.

- **MenuOptions.cs**
- **SortMenuOptions.cs**

### Exceptions

Contains custom exceptions.

- **EmptyInventoryException.cs** 
- **NameNotFoundException.cs**

### Helper

Provides utility methods.

- **ConsoleColorManager.cs** – Handles colored font console output.
- **TypeValidation.cs** – Validates user input types.
