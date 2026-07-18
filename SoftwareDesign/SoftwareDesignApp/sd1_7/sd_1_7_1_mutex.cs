namespace SoftwareDesign.sd1_7;

public class Sd171
{
    private static readonly Mutex Mutex = new Mutex();

    private static void UseResource()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} waiting mutex");
        Mutex.WaitOne();

        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} catch mutex.");
            Thread.Sleep(5000); 
        }
        finally
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} unlock mutex.");
            Mutex.ReleaseMutex();
        }
    }
}