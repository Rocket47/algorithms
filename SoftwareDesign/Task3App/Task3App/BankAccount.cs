namespace SoftwareDesign;

public class BankAccount(double balance) : IPaymentProcessor
{
    public void Deposit(double sum)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(sum);
        Balance += sum;
    }

    public void Withdraw(double sum)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(sum);

        ArgumentOutOfRangeException.ThrowIfGreaterThan(sum, Balance);

        Balance -= sum;   
    }

    public double Balance { get; private set; } = balance;
}