using System;

public class Class
{
    public void M()
    {
        try
        {
            Console.WriteLine("Try");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Catch 1");
        }
        catch (Exception)
        {
            Console.WriteLine("Catch 2");
        }
        finally
        {
            Console.WriteLine("Finally");
        }
    }
}
