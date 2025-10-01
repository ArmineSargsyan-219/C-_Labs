using System;

class BankAccount
{
    private string owner_name;
    private readonly string accountNumber;
    private decimal balance;

    public string Owner => owner_name;
    public string AccountNumber => accountNumber;
    public decimal Balance => balance;

    private static int totalAccounts = 0;
    public static int TotalAccounts => totalAccounts;

    public BankAccount(string ownername, string number, decimal initial = 0)
    {
        owner_name = string.IsNullOrWhiteSpace(ownername) ? throw new ArgumentNullException(nameof(ownername)) : ownername.Trim();
        accountNumber = string.IsNullOrWhiteSpace(number) ? throw new ArgumentNullException(nameof(number)) : number.Trim();
        if (initial < 0) throw new ArgumentOutOfRangeException(nameof(initial));
        balance = initial;

        totalAccounts++;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        if (amount > balance) throw new InvalidOperationException("Insufficient funds");
        balance -= amount;
    }

    

}

class Program
{
    static void Main()
    {
        try {
          Console.WriteLine("=== Create Accounts ===");

        BankAccount acc1 = new BankAccount("Alice", "A001", 1000);
        BankAccount acc2 = new BankAccount("Bob", "B002", 500);
        BankAccount acc3 = new BankAccount("Charlie", "C003");

        Console.WriteLine($"Total accounts created: {BankAccount.TotalAccounts}\n");

        acc1.Deposit(200);
        acc2.Withdraw(100);
        acc3.Deposit(50);

        Console.WriteLine($"{acc1.Owner} ({acc1.AccountNumber}) → Balance: ${acc1.Balance}");
        Console.WriteLine($"{acc2.Owner} ({acc2.AccountNumber}) → Balance: ${acc2.Balance}");
        Console.WriteLine($"{acc3.Owner} ({acc3.AccountNumber}) → Balance: ${acc3.Balance}");

        Console.WriteLine($"\nTotal accounts: {BankAccount.TotalAccounts}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
