using System;

namespace Day9
{
    public abstract class BankAccount
    {
        private ulong id;
        private Person owner;
        private double balance;
        private double bonuses;

        public BankAccount(ulong id, Person owner, double balance, double bonuses)
        {
            this.id = id;
            this.owner = owner;
            this.balance = balance;
            this.bonuses = bonuses;
        }

        public ulong Id
        {
            get { return id; }
            protected set { id = value; }
        }

        public Person Owner
        {
            get { return owner; }
            protected set { owner = value; }
        }

        public double Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        public double Bonuses
        {
            get { return bonuses; }
            protected set { bonuses = value; }
        }

        public abstract void DepositBonuses(double amount);

        public abstract void WithdrawBonuses(double amount);

        public void Withdraw(double amount)
        {
            if (balance - amount < 0)
            {
                throw new Exception("Not enough money");
            }

            balance -= amount;
            WithdrawBonuses(amount);
        }

        public void Deposit(double amount)
        {
            balance += amount;
            DepositBonuses(amount);
        }

        public class Person
        {
            private string name;
            private string surname;

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
        }
    }
}
