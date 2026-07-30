namespace ContactManager.Helpers
{
    /// <summary>
    /// Holds Original List & related CRUD Operations.
    /// </summary>
    public static class ConsoleColorManager
    {
        /// <summary>
        /// Sets color to the console.
        /// </summary>
        /// <param name="color">Color to be set.</param>
        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}