namespace Day9
{
    public interface IAccountGenerator
    {
        BankAccount Generate(string name, string surname, IStorage storage);
    }
}