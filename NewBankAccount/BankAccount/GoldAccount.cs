using System;

namespace Day9
{
    public class GoldAccount : BankAccount
    {
        private const double Coefficient = 0.02;

        public GoldAccount(ulong id, Person owner, double balance, double bonuses)
            : base(id, owner, balance, bonuses)
        {
        }

        public override void DepositBonuses(double amount)
        {
            this.Bonuses += amount * Coefficient;
        }

        public override void WithdrawBonuses(double amount)
        {
            this.Bonuses -= amount * Coefficient;
        }
    }
}
