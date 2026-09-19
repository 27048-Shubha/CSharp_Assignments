## Task 2: Synchronous vs Asynchronous File Processing - Observations

### Test Results

- Test 1:
```
[Sync] Completed: source1.txt to destination1.txt
[Sync] Completed: source2.txt to destination2.txt
[Sync] Completed: source3.txt to destination3.txt
Time take to read, process, write 3 files synchronously: 3534 milliseconds

[Async] Completed: source1.txt to destination1.txt
[Async] Completed: source2.txt to destination2.txt
[Async] Completed: source3.txt to destination3.txt
Time take to read, process, write 3 files asynchronously: 2587 milliseconds
Asynchronous file processing is faster than Synchronous file processing
```

- Test 2:
```
[Sync] Completed: source1.txt to destination1.txt
[Sync] Completed: source2.txt to destination2.txt
[Sync] Completed: source3.txt to destination3.txt
Time take to read, process, write 3 files synchronously: 3601 milliseconds

[Async] Completed: source2.txt to destination2.txt
[Async] Completed: source1.txt to destination1.txt
[Async] Completed: source3.txt to destination3.txt
Time take to read, process, write 3 files asynchronously: 3068 milliseconds
Asynchronous file processing is faster than Synchronous file processing
```

- Test 3:
```
[Sync] Completed: source1.txt to destination1.txt
[Sync] Completed: source2.txt to destination2.txt
[Sync] Completed: source3.txt to destination3.txt
Time take to read, process, write 3 files synchronously: 3449 milliseconds

[Async] Completed: source1.txt to destination1.txt
[Async] Completed: source3.txt to destination3.txt
[Async] Completed: source2.txt to destination2.txt
Time take to read, process, write 3 files asynchronously: 4042 milliseconds
Synchronous file processing is faster than Asynchronous file processing
```

### Observations

- In the first two runs, asynchronous file processing completed faster than synchronous processing.
- Asynchronous processing was able to handle multiple file operations concurrently, reducing the overall execution time.
- In the third run, synchronous processing performed better than asynchronous processing.
- The completion order of asynchronous tasks differed between runs, indicating that tasks were executed concurrently.
- Performance varied across executions due to factors such as system load, disk I/O availability, and task scheduling.

### Conclusion

- Asynchronous file processing generally provides better performance for handling multiple file operations simultaneously. 
- However, the results were not consistent across all runs, and synchronous processing was faster in one test case. 
- Therefore, asynchronous processing can improve throughput for I/O-bound operations, but actual performance depends on the system environment and runtime conditions.