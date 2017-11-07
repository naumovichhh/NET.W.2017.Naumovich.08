using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public interface IAccountType
    {
        void ProcessBonuses(BankAccount account, double amount);
    }

    public class BaseAccount : IAccountType
    {
        public void ProcessBonuses(BankAccount account, double amount)
        {
            account.ProcessBonuses(amount * coefficient);
        }

        private const double coefficient = 0.01;
    }

    public class GoldAccount : IAccountType
    {
        public void ProcessBonuses(BankAccount account, double amount)
        {
            account.ProcessBonuses(amount * coefficient);
        }

        private const double coefficient = 0.02;
    }

    public class PlatinumAccount : IAccountType
    {
        public void ProcessBonuses(BankAccount account, double amount)
        {
            account.ProcessBonuses(amount * coefficient);
        }

        private const double coefficient = 0.03;
    }
}
