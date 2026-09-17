
Attempt 1:
Time taken to read using file stream: 775 milliseconds
Time taken to read using buffered stream: 575 milliseconds

Attempt 2:
Time taken to read using file stream: 1220 milliseconds
Time taken to read using buffered stream: 996 milliseconds

Attempt 3:
Time taken to read using file stream: 1137 milliseconds
Time taken to read using buffered stream: 1007 milliseconds

Thus Reading by buffered stream is faster than file stream

Reason: 
BufferedStream introduces an additional in-memory buffer.

Accessing RAM is much faster than accessing disk storage.
BufferedStream's internal buffering mechanism reduces the number of direct interactions with the underlying file stream and minimizes expensive I/O operations.