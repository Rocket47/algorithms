using SoftwareDesign;
using Task3AppTests.Mock;
using Xunit;
using Assert = Xunit.Assert;

namespace Task3AppTests;

public class PaymentProcessorTests
{
    private readonly IPaymentProcessor FakePaymentBankAccount;
    private const double InitialSum = 1000;

    public PaymentProcessorTests()
    {
        FakePaymentBankAccount = new FakePaymentBankAccount(InitialSum);
    }
    
    [Fact]
    public void ShouldReturnZeroBalance()
    {
        FakePaymentBankAccount.Deposit(InitialSum);
        FakePaymentBankAccount.Withdraw(2* InitialSum);
        Assert.Equal(0, FakePaymentBankAccount.Balance);
    }
            
    [Fact]
    public void ShouldReturnExceptionIfBalanceNegative()
    {
        FakePaymentBankAccount.Deposit(InitialSum);
        Assert.Throws<ArgumentOutOfRangeException>(() => FakePaymentBankAccount.Withdraw(3 * InitialSum));
    }
}