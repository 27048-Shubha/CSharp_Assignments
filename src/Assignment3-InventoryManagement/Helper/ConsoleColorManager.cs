namespace Assignment3_InventoryManagement.Helper
{
    using System;

    /// <summary>
    /// Static class that manages console color.
    /// </summary>
    public static class ConsoleColorManager
    {
       /// <summary>
       /// Sets color to the console.
       /// </summary
       /// <param name="color">Color to be set.</param>
       public static void SetColor(ConsoleColor color)
       {
            Console.ForegroundColor = color;
       }
    }
}
