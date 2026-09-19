namespace Assignment15_FilesAndStream.Helper
{
    /// <summary>
    /// Manages file creation operation.
    /// </summary>
    public static class FileGenerator
    {
        /// <summary>
        /// Generates file in specified source path with specified target size.
        /// </summary>
        /// <param name="sourcePath">Path where file to be created in.</param>
        /// <param name="targetSize">Target size of the file.</param>
        public static void GenerateFile(string sourcePath, long targetSize)
        {
            if (!File.Exists(sourcePath))
            {
                using StreamWriter writer = new StreamWriter(sourcePath);
                Random random = new Random();
                int size = 0;

                while (size < targetSize)
                {
                    char randomCharacter = (char)random.Next('a', 'z' + 1);
                    writer.Write(randomCharacter);
                    size++;
                }
            }
        }
    }
}
