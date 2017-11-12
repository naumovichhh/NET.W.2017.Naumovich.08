namespace Day9
{
    public class DefaultAccountGenerator : IAccountGenerator
    {
        public BankAccount Generate(string name, string surname, IStorage storage)
        {
            ulong id = 0;
            while (storage.Exists(id))
            {
                ++id;
            }

            return new DefaultAccount(id, new BankAccount.Person(name, surname), 0, 0);
        }
    }
}
