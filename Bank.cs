using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT22_Thread_Bank_App
{
    internal class Bank
    {
        public List<Customer> customers = new List<Customer>();


        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void TransferMony()
        {
            Random random = new Random();
            int index1 = random.Next(customers.Count);
            int index2 = random.Next(customers.Count) - 1;

            if (index2 >= index1)
            {
                index2++;
            }
            Customer cus1 = customers[index1];
            Customer cus2 = customers[index2];

            decimal amount = random.Next(1, (int)cus1.Balance);
            cus1.Transfer(cus2, amount);
            Console.WriteLine($"Transfered {amount:C} from Cutomer {cus1.Id} To Customer {cus2.Id}");
        }
    }
}
