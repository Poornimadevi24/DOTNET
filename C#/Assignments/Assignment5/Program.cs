using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }
   

public class BankAccount
    {
        private double balance;

        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");

            balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");

            if (amount > balance)
                throw new InsufficientBalanceException("Insufficient balance!");

            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }

        public void CheckBalance()
        {
            Console.WriteLine("Current Balance: " + balance);
        }
    }
    internal class Program
    {
        static void Main()
            {
                try
                {
                    BankAccount acc = new BankAccount(1000);

                    acc.Deposit(500);
                    acc.Withdraw(2000); 
                    acc.CheckBalance();
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine("Custom Exception: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Argument Exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Exception: " + ex.Message);
                }
            }
        }
    
}
