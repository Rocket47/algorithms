namespace SoftwareDesign.sd1_7;

public class Sd173ManualEventReset
{
    private static readonly ManualResetEvent Locker = new ManualResetEvent(false);

    public static void Manage()
    {
        for (var i = 1; i <= 3; i++)
        {
            var thread = new Thread(Run)
            {
                Name = $"Thread {i}"
            };
            thread.Start();
        }
        Thread.Sleep(3000);
        
        Locker.Set(); 

        Console.ReadLine();
    }

    private static void Run()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} waiting...");
        
        Locker.WaitOne();
        
        Console.WriteLine($"{Thread.CurrentThread.Name} is running...");
    }
}