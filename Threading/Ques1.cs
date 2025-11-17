using System;
using System.Threading;

class Program
{
    static void PrintNumbers()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Thread A: {i}");
            Thread.Sleep(200); // 200 ms delay
        }
    }

    static void PrintLetters()
    {
        for (char c = 'A'; c <= 'J'; c++)
        {
            Console.WriteLine($"Thread B: {c}");
            Thread.Sleep(300); // 300 ms delay
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(PrintNumbers);
        Thread t2 = new Thread(PrintLetters);

        t1.Start();
        t2.Start();

        // Wait for both threads to finish
        t1.Join();
        t2.Join();

        Console.WriteLine("Both threads finished execution.");
    }
}

