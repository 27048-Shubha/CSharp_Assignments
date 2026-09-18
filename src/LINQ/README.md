# LINQ Tasks Console Application

## Overview

This is a menu-driven C# Console Application that demonstrates LINQ operations, collection manipulation techniques, performance comparisons, and a custom Query Builder implementation using Products, Suppliers, and Orders data.

The application loads sample data during startup and allows users to execute different tasks from the console menu.

---

## Features

### Task 1 - Product Filtering & Aggregation

- Filter Electronics products with price greater than 500.
- Sort products by price in descending order.
- Calculate the average product price.

### Task 2 - Grouping & Join Operations

- Generate category-wise summaries.
- Display:
  - Number of products in each category.
  - Most expensive product in each category.
- Perform an inner join between Products and Suppliers.

### Task 3 - Array-Based Problems

- Find the second highest number in an array.
- Find unique pairs whose sum matches a target value.

### Task 4 - LINQ Performance Comparison

Compare the performance of different approaches:

- Filter First LINQ Approach
- No LINQ Approach
- Manual Filter Then Query Approach
- Lookup Based Approach

Execution time for each approach is displayed and compared.

### Task 5 - Custom Query Builder

Demonstrates a custom Query Builder supporting:

- Filtering
- Sorting
- Joining
- Query Execution

Example:

```
queryBuilder
    .Filter(product => product.Price > 500)
    .SortBy(product => product.Price)
    .Join((product, supplier) => product.Id == supplier.SupplierId)
    .Execute();
```

---

## Application Flow

When the application starts:

1. Products are loaded into the system.
2. Suppliers are loaded into the system.
3. Orders are loaded into the system.
4. Loaded data is displayed in the console.
5. The task menu is presented to the user.

```text
1 - Task 1 : Product Filtering & Aggregation
2 - Task 2 : Grouping & Join Operations
3 - Task 3 : Array Problems
4 - Task 4 : LINQ Performance Comparison
5 - Task 5 : Custom Query Builder
6 - Quit
```
