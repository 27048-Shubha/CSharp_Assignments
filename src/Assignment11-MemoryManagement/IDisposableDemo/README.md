# Implementing and Understanding IDisposable and the `using` Statement

## Objective
Understand the purpose of the `IDisposable` interface, how the `using` statement automatically disposes objects, and how file resources are properly released.

## Implementation
1. Created a `FileWriter` class that implements `IDisposable`.
2. Opened a file using `StreamWriter`.
3. Wrote text to the file inside a `using` block.
4. Released the file resource in the `Dispose()` method.
5. Verified that the file could be accessed after the `using` block.

## Output

### Snapshot 1 - Entry of `using()`
- Objects: 4,141
- Heap Size: 526.13 KB

### Snapshot 2 - End of `using()`
- Objects: 4,602 (+461)
- Heap Size: 564.34 KB (+38.20 KB)

### Snapshot 3 - After `Dispose()`
- Objects: 4,597 (-5)
- Heap Size: 563.84 KB (-0.50 KB)

## Observations
1. Creating the `FileWriter` object opened the file and allocated related resources.
2. Writing to the file caused a small increase in memory usage due to stream and buffer allocations.
3. The object was automatically disposed when execution exited the `using` block.
4. `Dispose()` released the underlying `StreamWriter` and file handle.
5. After disposal, the file could be opened for reading without any errors.
6. Memory changes were minimal because the main purpose of `IDisposable` is resource cleanup, not memory reclamation.


## Conclusion
- `IDisposable` provides a mechanism for releasing unmanaged resources such as file handles.
- The `using` statement automatically invokes `Dispose()`, ensuring resources are cleaned up properly.
- Releasing the file resource allowed the same file to be opened for reading after the `using` block.
- This prevents resource leaks and promotes proper resource management.