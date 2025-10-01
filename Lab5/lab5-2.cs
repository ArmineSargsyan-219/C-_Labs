using System;

class BankAccount
{
    private string owner_name;
    private readonly string accountNumber;
    private decimal balance;

    public string Accountnumber => accountNumber;
    public decimal Balance => balance;

    public BankAccount(string ownername, string number, decimal initial = 0)
    {
        owner_name = string.IsNullOrWhiteSpace(ownername) ? throw new ArgumentNullException(nameof(ownername)) : ownername.Trim();
        accountNumber = string.IsNullOrWhiteSpace(number) ? throw new ArgumentNullException(nameof(number)) : number.Trim();
        if (initial < 0) throw new ArgumentOutOfRangeException(nameof(initial));
        balance = initial;
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
        try
        {
            Console.Write("Enter owner name: ");
            string owner = Console.ReadLine();

            Console.Write("Enter account number: ");
            string number = Console.ReadLine();

            Console.Write("Enter initial balance: ");
            decimal initial = decimal.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(owner, number, initial);
            Console.WriteLine($"\nAccount created! Balance: ${account.Balance}\n");

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"--- Operation {i} ---");
                Console.Write("Enter operation (D=Deposit, W=Withdraw): ");
                string operation = Console.ReadLine().ToUpper();

                Console.Write("Enter amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                if (operation == "D")
                {
                    account.Deposit(amount);
                    Console.WriteLine($"Deposited ${amount}. New balance: ${account.Balance}");
                }
                else if (operation == "W")
                {
                    account.Withdraw(amount);
                    Console.WriteLine($"Withdrew ${amount}. New balance: ${account.Balance}");
                }
                else
                {
                    Console.WriteLine("Invalid operation! Skipping...");
                    i--;
                }
                Console.WriteLine();
            }

            Console.WriteLine($"===================");
            Console.WriteLine($"Final Balance: ${account.Balance}");
            Console.WriteLine($"===================");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input format!");
        }
    }
}
