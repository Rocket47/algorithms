namespace SoftwareDesign.sd1_6;

/*
 В данном примере thread 1 блокирует критичную область памяти с помощью lock 1 (lock 2 внутри)
 а thread 2 пытается блокировать другую область кода, заблокировав lock 2 (lock 1 внутри).
 Но т.к объект lock 2 уже ожидает разблокировки - поток не может заблокировать его пока не освбодится lock 1
*/
public class sd1_6_2
{
        private static readonly object Lock1 = new  object();
        private static readonly object Lock2 = new();

        public static void RunDeadlocks()
        {
            var thread1 = new Thread(() =>
            {
                lock (Lock1)
                {
                    Thread.Sleep(50);

                    lock (Lock2)
                    {
                        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]");
                    }
                }
            });

            var thread2 = new Thread(() =>
            {
                lock (Lock1)
                {
                    Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]");
                    Thread.Sleep(50);

                    lock (Lock2)
                    {
                        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]");
                    }
                }
            });

            thread1.Start();
            thread1.Start();
            thread1.Join();
            thread2.Join();
        }
}