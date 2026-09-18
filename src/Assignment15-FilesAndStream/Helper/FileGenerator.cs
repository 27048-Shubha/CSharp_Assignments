using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15_FilesAndStream.Helper
{
    public static class FileGenerator
    {
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
