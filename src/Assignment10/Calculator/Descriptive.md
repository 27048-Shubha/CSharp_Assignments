1. Explain what the .NET platform is and its primary purpose. 
	- .NET platform is a software development platform developed and maintained by Microsoft
	- It provides runtime, libraries, compiler support, memory management, application frameworks needed to run applications.
	- Primary purpose of .NET platform: To provide runtime & common set of libraries so that developers can focus on building application without worrying about low-level memory management and platform specific complexities

---

2. What are the key components of the .NET platform? 
	- CLR (Common Language Runtime)
		- Executes applications and provides services such as GC (Garbage Collector), exception handling, security and JIT compilation.
	- BCL (Base Class Library)
		- Collection of reusable classes like List, String, File, etc.,
	- CTS (Common Type System)
		- Defines how data types are declared and used across .NET languages
	- CLS (Common Language Specification)
		- Set of rules ensuring interoperability among .NET languages (Example: C#, F#).
	- JIT Compiler
		- Converts intermediate language to native machine language.
	- Assemblies
		- Compiled deployment units containing IL, metadata and resources.

---

3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET. 
	- CLR (Common Language RunTime)
		- CLR is the execution engine of .NET .
		- It is responsible for running application and providing runtime services.
		- Runtime services includes memory management, garbage collection, JIT compilation, exception handling, security, thread management.
	- CTS (Common Type System)
		- CTS is a set of rules that defines all data types in .NET and how they behave.
		- It ensures all .NET languages understand the same types.
		- Unlike CLR, it doesn't handle memory, GC, JIT. It defines the datatype like String, Int32, Object, etc.,

---

4. What is the role of the Global Assembly Cache (GAC) in .NET? 
	- GAC (Global Assembly Cache) is a central repository used to store shared .NET assemblies that can be used by multiple applications on the same machine.
	- Only strong-named assemblies can be stored in GAC.
	- Strong-named contains assembly name, version, culture, public key token, etc.,

---

5. Explain the difference between value types and reference types in C#. 
	- Value type:
		- A value type stores the actual value directly.
		- Example: `int age = 25;` `double price = 99.99;` `bool isActive = true;` `char grade = 'A';` `struct Point { }`
		- Memory:
			- `x = 10; y = x;`
			- When assigning x to y, a copy of the value is created.
	- Reference type:
		- A reference type stores a reference(address) to an object.
		- Example: `class` `object` `delegate` 
		- Memory:
			- `Product p1 = new Product();`
               `Product p2 = p1;`
			- Both variables point to the same object.
	- Object stored on heap and reference stored on stack.

---

6. Describe the concept of garbage collection on .NET and its advantages. 
	- Garbage collection is an automatic memory management system provided by the CLR
	- It finds objects that are no longer being used and reclaim the memory occupied by them.
	- Without GC, developers would need to manually free memory.
	- It uses generational approach (Gen 0, 1, 2) where Gen 0 holds short lived data and Gen 2 holds long lived.
	- Advantages
		- Automatic memory management
		- Reduces memory leaks.
		- Reduces memory fragmentation.

---

7. What is the purpose of the Globalization and Localization features in .NET? 
	- Globalization
		- The process of designing an application so it can work with multiple cultures and regions.
		- Example: Currency and date formatting (dd/MM/yyyy) 
	- Localization
		- The process of adapting an application for a specific language or region.
		- Example: English, French, Tamil UI text.
---

8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 
	- When the application runs, the CLR (Common Language Runtime)'s JIT (Just In Time) compiler convertsthe CIL (Common Intermediate Language) into native machine code specific to the processor.
	- This enables platform independence, language interoperability and improves performance by compiling methods only when needed.

---
