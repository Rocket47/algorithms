namespace SoftwareDesign.sd1_6;

/*
 Ошибка со счетчиком _counter может возникнуть если 2 потока сделают одновременное чтение значения
 и попытаются выполнить увеличение счетчика. Lock или более быстрая функция Interlocked.Increment 
 делают увеличение счетчика атомарной операцией. 
*/
public class sd1_6_1
{
        private static int _counter = 0;

        public static void RunRaceCondition()
        {
            const int numberOfThreads = 10;
            
            Parallel.For(0, numberOfThreads, _ =>
            {
                for (var j = 0; j < 100_000; j++)
                {
                    Interlocked.Increment(ref _counter);
                }
            });

            Console.WriteLine($"{_counter}");
        }
}