### Task 6.2: Understanding IReadOnlyDictionary

#### Implementation

- Created `GenerateDictionary()` to return an `IReadOnlyDictionary<string, int>`.
- Created `PrintDictionary()` to display all key-value pairs.
- Attempted to modify the returned dictionary.

```csharp
IReadOnlyDictionary<string, int> dictionary = GenerateDictionary();

// Compile-time error
dictionary["Apple"] = 10;
```

#### Observation

- `IReadOnlyDictionary` allows reading data only.
- It prevents modification of the dictionary.
- Attempting to update a value results in compile-time error `CS0200`.

#### Reflection

This task helped me understand how `IReadOnlyDictionary` protects data from modification while still allowing read access. It improves