using Day9;
using System;
using System.Text;

namespace AtWork
{
    internal class Program
    {
        private static void Main(string[] args)
        {            
            var bankService = new BankAccountsService(new FileStorage());
            ulong id1 = bankService.CreateAccount("Vasily", "Vasilyev",
                new AbsoluteAccountGenerator());
            bankService.Deposit(id1, 1000);
            BankAccount account1 = bankService.GetAccountInfo(id1);
            Console.WriteLine(new StringBuilder().Append(account1.Id).Append(" balance:")
                .Append(account1.Balance).Append(" bonuses:").Append(account1.Bonuses));
            ulong id2 = bankService.CreateAccount("Roman", "Naumovich", 
                new DefaultAccountGenerator());
            bankService.Deposit(id2, 113245);
            bankService.Withdraw(id2, 13245);
            BankAccount account2 = bankService.GetAccountInfo(id2);
            Console.WriteLine(new StringBuilder().Append(account2.Id).Append(" balance:")
                .Append(account2.Balance).Append(" bonuses:").Append(account2.Bonuses));
            Console.ReadLine();
        }
    }
}
