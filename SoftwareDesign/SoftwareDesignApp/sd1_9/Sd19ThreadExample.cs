namespace SoftwareDesign.sd1_9;

public class Sd19ThreadExample
{
    private static int _counter;

    public static async Task IncreaseCounterAsync()
    {
        var task1 = IncrementCounterAsync();
        var task2 = IncrementCounterAsync();

        await Task.WhenAll(task1, task2);
    }

    private static Task IncrementCounterAsync() =>
        Task.Run(() =>
        {
            for (var i = 0; i < 1_000; i++)
            {
                Interlocked.Increment(ref _counter);
            }
        });
}