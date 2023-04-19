namespace SUT22_Thread_Bank_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.AddCustomer(new Customer(101, 1000));
            bank.AddCustomer(new Customer(102, 2000));
            bank.AddCustomer(new Customer(103, 3000));
            bank.AddCustomer(new Customer(104, 4000));




            Thread thread1 = new Thread(() =>
            {
                Random random = new Random();
                while (true)
                {
                    int index = random.Next(bank.customers.Count);
                    Customer cut = bank.customers[index];

                    decimal amount = random.Next(1, 101);
                    if(random.Next(2) == 0)
                    {
                        cut.Deposit(amount);
                        Console.WriteLine($"Deposited {amount:C} to Custmer {cut.Id}");
                    }
                    else
                    {
                        if (cut.Withdraw(amount))
                        {
                            Console.WriteLine($"Withdraw {amount:C} from Customer {cut.Id}");
                        }
                    }
                    Thread.Sleep(random.Next(1000, 2001));

                }
            });

            thread1.Start();




            Thread thread2 = new Thread(() =>
            {
                Random rand = new Random();
                while (true) 
                {
                    bank.TransferMony();
                    Thread.Sleep(rand.Next(2000, 3001));
                }
            });
            thread2.Start();

            Console.ReadKey();

        }
    }
}