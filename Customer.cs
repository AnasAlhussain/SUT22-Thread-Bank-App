using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT22_Thread_Bank_App
{
    internal class Customer
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public Customer(int id , decimal balance)
        {
            Id = id;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if(Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public void Transfer(Customer other,decimal amount)
        {
            if (Withdraw(amount))
            {
                other.Deposit(amount);
            }
        }
    }
}
