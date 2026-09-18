# Observation from Task 4 - Performance Comparison of Various Query Approaches

## Sample Iterations

### Filter First LINQ Based Approach

- Execution Time 1: 0.1245 ms
- Execution Time 2: 0.1216 ms
- Execution Time 3: 0.1269 ms

### No LINQ Approach

- Execution Time 1: 0.0512 ms
- Execution Time 2: 0.0432 ms
- Execution Time 3: 0.0519 ms

### Manual Filter Then Query Approach (LINQ + No LINQ)

- Execution Time 1: 0.0498 ms
- Execution Time 2: 0.1108 ms
- Execution Time 3: 0.0503 ms

### Lookup Based Approach

- Execution Time 1: 0.0545 ms
- Execution Time 2: 0.1320 ms
- Execution Time 3: 0.0502 ms


## Ranking (based on execution time)

1. **No LINQ Approach**
2. **Manual Filter Then Query Approach**
3. **Lookup Based Approach**
4. **Filter First LINQ Approach**

## Conclusion

- No LINQ Approach is fastest because it uses direct loops with minimal overhead.
- Manual Filter Then Query performs better by reducing the dataset before applying LINQ.
- Lookup Approach has an initial setup cost but becomes efficient for repeated searches.
- Filter First LINQ Approach is slower because LINQ adds extra processing layers.

Thus far large datasets, Lookup Approach is more suitable.