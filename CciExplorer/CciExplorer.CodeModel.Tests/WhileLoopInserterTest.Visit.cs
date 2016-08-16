using System;

public class Class
{
    public void M()
    {
        bool b = true;

        Console.WriteLine("Before while");
        while (b == true)
        {
            Console.WriteLine("In while");
        }
        Console.WriteLine("End while");
    }
}
