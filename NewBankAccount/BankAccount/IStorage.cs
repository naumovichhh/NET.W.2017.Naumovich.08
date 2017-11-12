using System;
using System.IO;
using System.Reflection;

namespace Day9
{        
    public interface IStorage
    {
        void StoreAccount(BankAccount account);

        BankAccount LoadAccount(ulong id);

        void DeleteAccount(ulong id);

        bool Exists(ulong id);
    }

    public class FileStorage : IStorage
    {
        public FileStorage()
        {
            if (!Directory.Exists("accounts"))
            {
                Directory.CreateDirectory("accounts");
            }
        }

        public void StoreAccount(BankAccount account)
        {
            using (var writer = new BinaryWriter(
                File.Open("accounts/" + account.Id.ToString(), FileMode.Create)))
            {
                writer.Write(account.GetType().ToString());
                writer.Write(account.Owner.Name);
                writer.Write(account.Owner.Surname);
                writer.Write(account.Balance);
                writer.Write(account.Bonuses);
            }
        }

        public BankAccount LoadAccount(ulong id)
        {
            try
            {
                using (var reader = new BinaryReader(
                    File.Open("accounts/" + id.ToString(), FileMode.Open)))
                {
                    string typeid = reader.ReadString();
                    string name = reader.ReadString();
                    string surname = reader.ReadString();
                    double balance = reader.ReadDouble();
                    double bonuses = reader.ReadDouble();
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    Type accounttype = null;
                    foreach (var asm in assemblies)
                    {
                        accounttype = asm.GetType(typeid);
                        if (accounttype != null)
                        {
                            break;
                        }
                    }

                    if (accounttype == null)
                    {
                        throw new AccountTypeNotFoundException(id);
                    }

                    BankAccount account = (BankAccount)Activator.CreateInstance(
                        accounttype, id, new BankAccount.Person(name, surname), balance, bonuses);
                    return account;
                }
            }
            catch (FileNotFoundException)
            {
                throw new InvalidAccountIdException(id);
            }
        }

        public void DeleteAccount(ulong id)
        {
            try
            {
                File.Delete("accounts/" + id.ToString());
            }
            catch
            {
                throw new InvalidAccountIdException(id);
            }
        }

        public bool Exists(ulong id)
        {
            return File.Exists("accounts/" + id.ToString());
        }
    }
}
