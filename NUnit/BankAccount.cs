using System.Diagnostics;
namespace NUnit;
public class BankAccount
{
    private double balance;

    public BankAccount()
    {
    }

    public BankAccount(double balance)
    {
        this.balance = balance;
    }

    public double Balance
    {
        get { return balance; }
    }

    public void Add(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        balance -= amount;
    }

    public static void Main(string[] args) { }
}
