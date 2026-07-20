namespace SoftwareDesign.sd1_10;

public class Sd10ParallelismExample
{
    private const int Size = 1_000_000;
    private const int Threads = 4;

    public static long GetSum()
    {
        var data = new int[Size];

        for (var i = 0; i < data.Length; i++)
        {
            data[i] = Random.Shared.Next(100);
        }

        return data
            .AsParallel()
            .WithDegreeOfParallelism(Threads)
            .Sum(value => (long)value);
    }
}