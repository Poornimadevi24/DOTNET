/*Inheritance:

1.Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type (d/w), amount, balance
D->Deposit
W->Withdrawal

-write a function that updates the balance depending upon the transaction type

	-If transaction type is deposit call the function credit by passing the amount to be deposited and update the balance

  function  Credit(int amount)  (int or float or double - anything yo can use)

	-If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance

  Debit(int amt) function 

-Pass the other information like Account no, customer name, acc type through constructor

-write and call the show data method to display the values.*/
using System;

namespace Assignment3
{
    class Accounts
    {
        protected int AccountNo;
        protected string CustomerName;
        protected string AccountType;
        protected double balance;

        public Accounts(int accNo, string name, string type, double bal)
        {
            AccountNo = accNo;
            CustomerName = name;
            AccountType = type;
            balance = bal;
        }

        public void Credit(double amount)
        {
            balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }

        public void Debit(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Withdrawn: " + amount);
            }
            else
            {
                Console.WriteLine("Insufficient Balance!");
            }
        }

        public void UpdateBalance(char transType, double amount)
        {
            if (transType == 'D' || transType == 'd')
                Credit(amount);
            else if (transType == 'W' || transType == 'w')
                Debit(amount);
            else
                Console.WriteLine("Invalid Transaction!");
        }

        public void ShowData()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine("Account No: " + AccountNo);
            Console.WriteLine("Customer Name: " + CustomerName);
            Console.WriteLine("Account Type: " + AccountType);
            Console.WriteLine("Balance: " + balance);
        }
    }

    class SavingsAccount : Accounts
    {
        public SavingsAccount(int accNo, string name, double bal)
            : base(accNo, name, "Savings", bal)
        {
        }
    }

    class Program
    {
        static void Main()
        {
            SavingsAccount acc = new SavingsAccount(101, "John", 5000);

            acc.UpdateBalance('D', 2000);
            acc.UpdateBalance('W', 1000);
            acc.ShowData();
        }
    }
}