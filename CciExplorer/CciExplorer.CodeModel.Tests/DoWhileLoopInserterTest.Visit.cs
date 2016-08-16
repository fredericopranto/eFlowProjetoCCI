using System;

public class Class
{
    public void M()
    {
        bool b = true;

        Console.WriteLine("Before while");
        do
        {
            Console.WriteLine("In while");
        }
        while (b == true);
        Console.WriteLine("End while");
    }
}
