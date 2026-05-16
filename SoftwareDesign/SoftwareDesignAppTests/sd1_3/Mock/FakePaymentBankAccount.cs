using SoftwareDesign;

namespace Task3AppTests.Mock;

public class FakePaymentBankAccount : IPaymentProcessor
{
    private readonly IPaymentProcessor bankAccount;

    public FakePaymentBankAccount(double initialSum)
    {
        bankAccount = new BankAccount(initialSum);
    }

    public void Deposit(double sum)
    {
        Console.WriteLine($"deposit sum {sum}");
        bankAccount.Deposit(sum);
    }

    public void Withdraw(double sum)
    {
        Console.WriteLine($"Withdraw {sum}");
        bankAccount.Withdraw(sum);
    }

    public double Balance { get; }
}