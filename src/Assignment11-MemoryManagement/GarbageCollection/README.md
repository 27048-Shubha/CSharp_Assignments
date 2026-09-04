# Using Garbage Collection and Understanding Its Impact on Performance

## Objective
Understand how Garbage Collection (GC) works in C# and observe its impact on memory usage and application performance.

## Implementation
1. Created **10,000,000 `Student` objects** using a loop.
2. Stored the objects in a `List<Student>` to keep them alive.
3. Removed the reference by setting the list to `null`.
4. Triggered garbage collection using `GC.Collect()`.

## Output

### Snapshot 1 (Before GC)
- Objects: 1,00,04,624
- Heap Size: 4,44,135.19 KB

### Snapshot 2 (After GC)
- Objects: Reduced after collection
- Heap Size: Reduced after collection

## Observations
1. A large number of `Student` objects were created and stored in memory.
2. Heap memory usage increased significantly because all objects were referenced by the `List<Student>`.
3. Snapshot 1 was captured before garbage collection.
4. Setting `_students = null` removed references to the objects.
5. The objects became eligible for garbage collection.
6. `GC.Collect()` was used to manually trigger garbage collection.
7. Heap memory usage decreased after unreachable objects were reclaimed.
8. Garbage collection introduced additional processing overhead while reclaiming memory.


## Conclusion
- Objects created using `new` are allocated on the **managed heap**.
- Objects remain in memory as long as they are referenced.
- Removing references makes objects eligible for garbage collection.
- Garbage Collection automatically reclaims unused memory.
- Triggering GC reduces memory usage but can impact performance because the runtime must identify and clean up unreachable objects.