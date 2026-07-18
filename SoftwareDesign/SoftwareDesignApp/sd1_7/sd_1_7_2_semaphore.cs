namespace SoftwareDesign.sd1_7;

public class Sd172Semaphore
{
    private static readonly SemaphoreSlim _semaphorePool = new SemaphoreSlim(5, 5);

    private static async Task UpdateDb()
    {
        var tasks = new Task[8];
        
        for (var i = 1; i <= 8; i++)
        {
            var userId = i;
            tasks[i - 1] = Task.Run(() => ConnectToDatabase(userId));
        
        }
        await Task.WhenAll(tasks);
        Console.WriteLine("Update is done.");
    }

    static void ConnectToDatabase(int userId)
    {
        _semaphorePool.Wait();

        try
        {
            Thread.Sleep(3000); 
        }
        finally
        {
            _semaphorePool.Release();
        }
    }
}