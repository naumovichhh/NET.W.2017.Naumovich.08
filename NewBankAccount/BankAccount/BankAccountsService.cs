namespace Day9
{
    public class BankAccountsService
    {
        private IStorage storage;

        public BankAccountsService(IStorage storage)
        {
            this.storage = storage;
        }

        public ulong CreateAccount(string name, string surname, IAccountGenerator generator)
        {
            var account = generator.Generate(name, surname, storage);
            storage.StoreAccount(account);
            return account.Id;
        }

        public void CloseAccount(ulong id)
        {
            storage.DeleteAccount(id);
        }

        public void Withdraw(ulong id, int amount)
        {
            var account = storage.LoadAccount(id);
            account.Withdraw(amount);
            storage.StoreAccount(account);
        }

        public void Deposit(ulong id, int amount)
        {
            var account = storage.LoadAccount(id);
            account.Deposit(amount);
            storage.StoreAccount(account);
        }

        public BankAccount GetAccountInfo(ulong id)
        {
            return storage.LoadAccount(id);
        }
    }
}
