namespace Assignment17_Reflections.Task_5.IPlugin
{
    public interface IPlugin
    {
        public string Name { get; }
        public void Encrypt(string passwod);

        public void Decrypt();

        public void Display(string message, string password);
    }
}