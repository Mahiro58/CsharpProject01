using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Konto
    {
        private long id;
        private string firstName;
        private string lastName;
        private decimal balance;
        private bool isActive;

        public List<Transactions> Transactions { get; private set; } = new();


        public Konto(long id, string firstName, string lastName)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id have to be greater than 0.");
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName cannot be null.");
            }


            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = 0;
            this.isActive = true;
        }

        public long Id 
        { get 
            { return id; } 
        }

        public string FirstName 
        { get 
            { return firstName; } 
        }

        public string LastName
        {
            get
            { return lastName; }
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public bool IsActive
        {
            get { return isActive; }
        }

        public void Deposit(decimal amount)
        {
            if (!IsActive)
            {
                Console.WriteLine("You cannot deposit to a closed account.");
            }
            else if (amount < 0)
            {
                Console.WriteLine("You cannot deposit negative amount.");
            }
            else
            {
                Console.WriteLine($"You added {amount} to your account.");
                balance += amount;
                Transactions.Add(new Transactions("Deposit", amount));
            }
        }

        public void Withdraw(decimal amount)
        {
            if (!IsActive)
            {
                Console.WriteLine("You cannot withdraw from a closed account.");
            }
            else if (amount < 0)
            {
                Console.WriteLine("You cannot withdraw negative amount.");
            }
            else if (balance < amount)
            {
                Console.WriteLine("Not enough money for withdraw.");
            }
            else
            {
                balance -= amount;
                Transactions.Add(new Transactions("Withdraw", amount));
            }
        }

        public void Close()
        {
            if (balance != 0)
            {
                Console.WriteLine("You cannot close your account with money in it.");
            }
            else
            {
                Console.WriteLine("Account closed.");
                isActive = false;
            }
        }

        public void CheckBalance()
        {
            if (isActive)
            {
                Console.WriteLine($"Your balance is: {balance}");
            }
            else
            {
                Console.WriteLine("Your account is closed.");
            }
        }

        public void PrintTransactions()
        {
            if (Transactions.Count == 0)
            {
                Console.WriteLine("No transactions yet.");
            }
            else
            {
                Console.WriteLine("Transactions:");
                foreach (var transaction in Transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
        }


    }
}
