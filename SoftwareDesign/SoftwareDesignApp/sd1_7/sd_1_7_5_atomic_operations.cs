namespace SoftwareDesign.sd1_7;

public class Sd175AtomicOperations
{
    private static int _counter = 0;
    private static int _atomicCounter = 0;

    private static async Task ImitateAtomicOperationsAsync()
    {
        var tasks = new Task[100];
        
        for (var i = 0; i < 100; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (var j = 0; j < 1000; j++)
                {
                    _counter++;
                    
                    Interlocked.Increment(ref _atomicCounter);
                }
            });
        }

        await Task.WhenAll(tasks);
        
        Console.WriteLine($"Without safety: {_counter}"); 
        Console.WriteLine($"Safety mode {_atomicCounter}");
    }
}