using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Transactions
    {
        public string Type { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }

        public Transactions(string type, decimal amount)
        {
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }

    }
}
