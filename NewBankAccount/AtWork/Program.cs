using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountsService.CreateAccount(new BankAccount(
                25235, new Person("Michael", "Smith"), new GoldAccount()));
            BankAccountsService.Put(25235, 2352);
            Console.WriteLine(BankAccountsService.GetAccount(25235).Balance);
            Console.WriteLine(BankAccountsService.GetAccount(25235).Bonuses + '\n');
            BankAccountsService.CloseAccount(25235);
            try
            {
                Console.WriteLine(BankAccountsService.GetAccount(25235).Balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
