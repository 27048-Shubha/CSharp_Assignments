## Task 3: Investigate Issues in Basic File Usage
### Issues Identified

1. Unnecessary MemoryStream Usage

	Data was first written to a MemoryStream and then copied to a FileStream.
This created an additional memory allocation that was not required.

2. Use of ASCII Encoding			

	Encoding.ASCII supports only a limited character set.
Encoding.UTF8 is the recommended encoding as it supports a wider range of characters.

3. Character-by-Character Output	

	The file content was read and displayed one character at a time. 
This resulted in many unnecessary console operations and reduced performance.

4. Reading Entire Buffer Instead of Actual Bytes Read

	When converting bytes to text, only the number of bytes returned by Read() should be processed.
Otherwise, unused bytes in the buffer may also be converted.

### Fixes Applied
1. Removed the MemoryStream and wrote data directly to the file using FileStream.
2. Replaced Encoding.ASCII with Encoding.UTF8.
3. Converted the byte array to a string and printed the content at once instead of character-by-character.
Used bytesRead while converting bytes to text.