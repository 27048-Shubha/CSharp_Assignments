## Task 4: Logger Analysis - Observations
### Issues Identified
1. The original logger used extra memory by writing to a memory stream before writing to the file.
2. Multiple users writing to the same log file at the same time can cause file access conflicts.
3. Using a single shared log file can reduce performance during concurrent logging.

### Improvements Made
1. Removed the unnecessary memory stream and wrote directly to the file.
2. Added a lock mechanism to ensure only one thread writes to the log file at a time.
3. Created separate log files for each thread/user to avoid file contention.

### Performance Test Observations
1. Locked logging prevented concurrency issues but introduced some waiting between threads.
2. Individual log files provided the best performance because threads did not compete for the same file, therefore avoided Race Condition
