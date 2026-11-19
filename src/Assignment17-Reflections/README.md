# Assignment 17 | Reflection in C#

This assignment demonstrates advanced Reflection and Reflection.Emit concepts in C#. It covers runtime assembly inspection, object analysis, dynamic method invocation, runtime mock generation, and serializer performance comparison.

---
# Implementation Details of Individual Tasks

# Task 1 - Assembly Metadata Inspector

`Task1.cs` inspects the currently executing assembly and displays metadata information about all eligible types available within the namespace.


- Loads the current assembly using Reflection.
- Identifies all non-nested types within the target namespace.
- Displays assembly information.
- Enumerates methods, properties, fields, events
- Uses Reflection APIs to extract metadata at runtime.

---

# Task 2 - Dynamic Object Inspector

`Task2.cs` demonstrates how Reflection can be used to inspect and modify object properties dynamically during runtime.

- Inspects object metadata at runtime.
- Displays all public properties and their current values.
- Modifies property values dynamically using property names.
- Supports automatic type conversion while updating values.
- Handles missing or read-only properties gracefully.

---

# Task 3 - Dynamic Method Invoker

`Task3.cs` demonstrates how methods can be discovered and executed dynamically using Reflection.

- Searches methods by name during runtime.
- Executes matching methods dynamically.
- Displays invocation status messages.
- Handles invalid method names without crashing.

---

# Task 4 - Dynamic Type Builder

`Task4.cs` demonstrates runtime type generation using Reflection.Emit. A `Book` class is created dynamically in memory without writing or compiling any source code.


- Creates a dynamic assembly and module at runtime.
- Generates a new type named `Book`.
- Creates a private backing field for storing book information.
- Dynamically generates a property named `Name`.
- Generates getter and setter methods using IL instructions.
- Creates a custom method named `DisplayDetails`.
- Instantiates and uses the generated type at runtime.

---

# Task 5 - Plugin System

`Task5.cs` demonstrates a plugin-based architecture using Reflection. External assemblies are scanned at runtime, and classes implementing the `IPlugin` interface are discovered and loaded dynamically.


- Dynamically loads assemblies from the application directory.
- Scans DLL files for eligible plugins.
- Detects classes implementing the `IPlugin` interface.
- Instantiates plugins without compile-time references.
- Provides a menu-driven plugin execution system.
- Supports adding new plugins without modifying existing code.

---

# Task 6 - Dynamic Mocking Framework

Task6.cs demonstrates how to create a mock implementation of an interface dynamically using Reflection.Emit and Intermediate Language (IL) generation.

- Creates assemblies dynamically at runtime.
- Generates types using `TypeBuilder`.
- Implements interfaces without writing source code.
- Creates constructors, fields, and methods dynamically.
- Emits IL instructions using `ILGenerator`.
- Instantiates generated types using `Activator.CreateInstance()`.

---

# Task 7 - Reflection vs Emit Serializer Performance Comparison

Task7.cs compares Reflection-based serialization and Reflection.Emit-based serialization to evaluate correctness and performance.

- Serializes multiple object types.
- Compares Reflection and Emit serializer outputs.
- Validates serialization correctness.
- Measures execution performance using `Stopwatch`.
- Demonstrates performance improvements provided by generated IL code.
