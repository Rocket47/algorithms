using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace SoftwareDesign
{
    public class Sd1_2
    {
        public class BankAccount(double balance) : IPaymentProcessor
        {
            public void Deposit(double sum) => Balance += sum;

            public void Withdraw(double sum) => Balance -= sum;

            public double Balance { get; private set; } = balance;
        }

        public interface IPaymentProcessor
        {
            void Deposit(double sum);
            void Withdraw(double sum);
            double Balance { get; }
        }

    public class FakePaymentBankAccount : IPaymentProcessor
    {
        private readonly IPaymentProcessor bankAccount;

        public FakePaymentBankAccount(double initialSum)
        {
            bankAccount = new BankAccount(initialSum);
        }

        public double Calculate(double sumToIncrease, double sumToDecrease)
        {
            Console.WriteLine("Operation in progress...");
            bankAccount.Deposit(sumToIncrease);
            bankAccount.Withdraw(sumToIncrease);
            Console.WriteLine($"Current balance is {bankAccount.Balance}");
        }
    }

    public class PaymentProcessorTests
    {
        private readonly IPaymentProcessor fakePaymentBankAccount;

        public PaymentProcessorTests()
        {
            fakePaymentBankAccount = new FakePaymentBankAccount(300);
            fakePaymentBankAccount.Calculate(200, 500);
            Assert.Equals(0, fakePaymentBankAccount.Balance);
        }
    }
    }
}