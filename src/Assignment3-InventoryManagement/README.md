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

## Guide for navigating through the application

1. Run the application.
2. Choose an option from the main menu:

   - 1 to Add Product
   - 2 to Edit Product
   - 3 to Delete Product
   - 4 to View Products
   - 5 to Search Product
   - 6 to Exit

3. Enter the required product details when prompted.
4. For editing or deleting, provide the product name.
5. View displays all available products in the inventory.
6. Search displays products matching the entered name.
7. Invalid inputs and errors are displayed with appropriate messages.
8. Select **Exit** to close the application.

## Error Handling

- **Add Product**
  - Validates positive price and non-negative stock.
  - Handles `ArgumentException`.

- **Edit Product**
  - Throws `EmptyInventoryException` if inventory is empty.
  - Throws `NameNotFoundException` if product is not found.

- **Delete Product**
  - Throws `EmptyInventoryException` if inventory is empty.
  - Throws `NameNotFoundException` if product is not found.

- **View Products**
  - Throws `EmptyInventoryException` when no products are available.

- **Search Product**
  - Displays a message when inventory is empty.
  - Handles product not found scenarios.

- **Global Exception Handling**
  - Catches and displays:
    - `EmptyInventoryException`
    - `NameNotFoundException`
    - General `Exception`