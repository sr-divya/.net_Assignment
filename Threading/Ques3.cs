using System;
using System.Threading;

class BankAccount
{
    public int Balance = 0;

    public void Deposit(int amount)
    {
        int temp = Balance;
        temp += amount;
        Thread.Sleep(10); // Simulate delay
        Balance = temp;
    }

    public void Withdraw(int amount)
    {
        int temp = Balance;
        temp -= amount;
        Thread.Sleep(10);
        Balance = temp;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();
        Thread t1 = new Thread(() => { for (int i = 0; i < 10; i++) account.Deposit(100); });
        Thread t2 = new Thread(() => { for (int i = 0; i < 10; i++) account.Withdraw(100); });

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Console.WriteLine($"Final Balance (without lock): {account.Balance}");
    }
}



