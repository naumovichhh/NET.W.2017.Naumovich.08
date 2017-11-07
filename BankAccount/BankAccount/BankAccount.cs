using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class BankAccount
    {
        public BankAccount(ulong newId, Person newOwner, 
            IAccountType accType, double newBalance = 0)
        {
            id = newId;
            owner = newOwner;
            balance = newBalance;
            accountType = accType;
            bonuses = 0;
        }

        public void Withdraw(double amount)
        {
            if (balance - amount < 0)
                throw new Exception("Not enough money");
            balance -= amount;
            accountType.ProcessBonuses(this, amount);
        }

        public void Put(double amount)
        {
            balance += amount;
            accountType.ProcessBonuses(this, amount);
        }

        public void ProcessBonuses(double amount)
        {
            bonuses += amount;
        }

        public IAccountType type;
        public ulong Id { get { return id; } }
        public Person Owner { get { return owner; } }
        public double Balance { get { return balance; } }
        public double Bonuses { get { return bonuses; } }
        public string AccountType { get { return accountType.ToString(); } }

        IAccountType accountType;
        private ulong id;
        private Person owner;
        private double balance;
        private double bonuses;
    }

    public class Person
    {
        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public string Name
        {
            get { return name; }
        }
        public string Surname
        {
            get { return surname; }
        }

        private string name;
        private string surname;
    }
}
