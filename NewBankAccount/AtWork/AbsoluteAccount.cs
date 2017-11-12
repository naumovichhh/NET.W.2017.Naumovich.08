using Day9;

namespace AtWork
{
    internal class AbsoluteAccount : BankAccount
    {
        public AbsoluteAccount(ulong id, Person owner, double balance, double bonuses)
            : base(id, owner, balance, bonuses)
        {
        }

        public override void DepositBonuses(double amount)
        {
            this.Bonuses += amount;
        }

        public override void WithdrawBonuses(double amount)
        {
            this.Bonuses -= amount;
        }
    }
}
