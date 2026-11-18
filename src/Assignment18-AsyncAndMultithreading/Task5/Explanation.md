# Task 5: Debugging and Fixing Deadlock Conditions

## Deadlock code:
```
internal class DeadLockSimulator
{
    public async Task DeadlockMethod()
    {
        // Note: Do not use .Result or .Wait() in production code.
        var result = await SomeAsyncOperation();
        Console.WriteLine(result);
    }

    public async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(1000);
        return "Hello, World!";
    }

}
```

## Why deadlock happened?

- Uses .Result instead of await.
- .Result blocks the calling thread.
- await tries to resume on the captured synchronization context.
- The required thread is already blocked.
- Both sides wait for each other, causing a deadlock.

## How is it fixed?

- Replace .Result with await.
- await does not block the thread.
- The thread is available for the continuation.
- The async operation completes normally.
- No circular dependency, hence no deadlock.