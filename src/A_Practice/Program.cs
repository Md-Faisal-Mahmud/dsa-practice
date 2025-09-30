//using System;
//using System.Threading;
//using System.Threading.Tasks;

//public class BankAccount
//{
//    public int Balance { get; set; }  // <-- Mutable

//    public void Deposit(int amount)
//    {
//        Balance += amount;  // ❌ Not thread-safe
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        var account = new BankAccount { Balance = 0 };

//        // Run 1000 deposits in parallel
//        Parallel.For(0, 1000, i =>
//        {
//            account.Deposit(1);
//        });

//        Console.WriteLine($"Final Balance = {account.Balance}");
//    }
//}


//using System;
//using System.Threading.Tasks;

//public record BankAccount(int Balance) // <-- Immutable
//{
//    public BankAccount Deposit(int amount)
//        => new BankAccount(Balance + amount);
//}

//class Program
//{
//    static void Main()
//    {
//        var account = new BankAccount(0);

//        Parallel.For(0, 1000, i =>
//        {
//            // Each thread creates its own copy, no shared mutation
//            account = account.Deposit(1);
//        });

//        Console.WriteLine($"Final Balance = {account.Balance}");
//    }
//}


using System;
using System.Linq;
using System.Threading.Tasks;

public record BankAccount(int Balance)
{
    public BankAccount Deposit(int amount)
        => new BankAccount(Balance + amount);
}

class Program
{
    static void Main()
    {
        var deposits = Enumerable.Range(0, 1000);

        // Each thread creates its own account and returns it
        var results = deposits.AsParallel()
                              .Select(_ => new BankAccount(0).Deposit(1))
                              .ToList();

        // Aggregate safely
        var finalAccount = new BankAccount(results.Sum(a => a.Balance));

        Console.WriteLine($"Final Balance = {finalAccount.Balance}");
    }
}

