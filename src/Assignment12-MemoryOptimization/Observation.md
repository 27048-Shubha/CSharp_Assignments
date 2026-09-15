# Issue

The following line is responsible for the memory growth:

```
memAlloc.Add(new int[1000]);
```

Although the loop is infinite, the primary problem is that every newly created array is stored in the memAlloc collection.

For each iteration:

- A new array of 1000 integers is allocated on the managed heap.
- A reference to that array is added to memAlloc.
- The collection continuously grows without removing older entries.

As a result, all arrays remain reachable through the memAlloc list.


Since the Garbage Collector only reclaims unreachable objects, these arrays cannot be collected. Consequently, heap memory usage keeps increasing and may eventually result in excessive memory consumption or an `OutOfMemoryException`.

---

# Solutions:

## 1: Avoid Retaining Unnecessary References


```
while (true)
{
    int[] numbers = new int[1000];
    Thread.Sleep(10);
}
```

Here,

- Memory allocations still occur.
- Arrays become unreachable after each iteration.
- The Garbage Collector can reclaim the memory.
- Memory usage remains bounded.

---

## Solution 2: Use a Bounded Collection

```
while (true)
{
    memAlloc.Add(new int[threshold]);

    if (memAlloc.Count > threshold)
    {
        // Return or Warning message.
    }

    Thread.Sleep(10);
}
```
Here,

- The collection size remains bounded.
- Old references are removed periodically.
- Heap usage stabilizes instead of growing indefinitely.

---
Common Assumption: 

- The infinite loop itself is not the root cause of the issue as it doesn't continuously consume memory because no objects are being accumulated.
- The actual problem arises because newly allocated arrays are continuously retained in the memAlloc collection. 
- As long as these references exist, the Garbage Collector cannot reclaim the occupied memory.
