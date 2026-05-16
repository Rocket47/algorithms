namespace SoftwareDesign;

public interface IPaymentProcessor
{
    void Deposit(double sum);
    void Withdraw(double sum);
    double Balance { get; }
}