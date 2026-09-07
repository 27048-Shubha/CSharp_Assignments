# Working with the Stack and the Heap

## Objective
Understand how memory is utilized in the Stack and Heap using C# and Visual Studio Diagnostic Tools.

## Methods Created
1. **Large Array Method**: Creates an `int[10_000_000]` array (reference type).
2. **Calculation Method**: Uses multiple local `int` variables (value types) for calculations.

## Output

### Snapshot 1
- Objects: 4,231
- Heap Size: 39,597.68 KB

### Snapshot 2
- Objects: 4,226 (-5)
- Heap Size: 535.12 KB (-39,062.56 KB)

## Observations
1. A large `int[]` array was created.
2. The array occupied approximately **39 MB** on the managed heap.
3. Snapshot 1 was captured after allocation.
4. The array became unreachable and was garbage collected.
5. The calculation method executed using local value-type variables.
6. Snapshot 2 was captured after memory cleanup.
7. Heap memory reduced by approximately **39 MB**.

## Memory Calculation

```text
int = 4 bytes
10,000,000 × 4 = 40,000,000 bytes
? 38–40 MB
```

## Conclusion
- The large array significantly increased **heap memory usage** because arrays are reference types.
- Local value-type variables primarily use **stack memory**.
- Stack usage was not visibly reflected in the Memory Usage profiler because it is relatively small.