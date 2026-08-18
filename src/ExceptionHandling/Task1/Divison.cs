using System;
public class Divison
{
    public void Divide(int dividend, int divisor)
    {
        bool status = true;
        try
        {
            Console.WriteLine($"Division result of {dividend} / {divisor} = {dividend / divisor}");
        }
        catch (DivideByZeroException exception)
        {
            status = false;
            Console.WriteLine("Divisor should not be zero");
        }
        finally
        {
            Console.WriteLine($"Operation status: {status}");
        }
    }

    public void Run()
    {
        Console.WriteLine("Enter number1: ");
        int number1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number2: ");
        int number2 = int.Parse(Console.ReadLine());

        this.Divide(number1, number2);
    }
}