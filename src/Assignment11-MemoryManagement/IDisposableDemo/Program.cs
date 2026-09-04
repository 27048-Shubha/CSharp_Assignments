namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (FileWriter writer = new FileWriter())
            {
                writer.WriteFile("Hello world!");
            }
        }
    }

    public class FileWriter : IDisposable
    {
        private StreamWriter _writer;
        private readonly string _filePath = "./TextFile.txt";

        internal FileWriter()
        {
            this._writer = new StreamWriter(this._filePath);
        }

        public void WriteFile(string text)
        {
            this._writer.WriteLine(text);
        }

        public void Dispose()
        {
            this._writer.Dispose();
            this._writer.Close();
        }
    }
}