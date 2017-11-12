using Day9;

namespace AtWork
{
    internal class AbsoluteAccountGenerator : IAccountGenerator
    {
        public BankAccount Generate(string name, string surname, IStorage storage)
        {
            ulong id = 0;
            while (storage.Exists(id))
            {
                ++id;
            }

            return new AbsoluteAccount(id, new BankAccount.Person(name, surname), 0, 0);
        }
    }
}
