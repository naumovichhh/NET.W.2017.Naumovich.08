using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Day8
{
    class BankAccountsService
    {
        public void CreateAccount(BankAccount account)
        {
            using (var writer = new BinaryWriter(
                File.Open(account.Id.ToString(), FileMode.Create)))
            {
                writer.Write(account.Id);
                writer.Write(account.Owner.Name);
                writer.Write(account.Owner.Surname);
                writer.Write(account.Balance);
                writer.Write(account.Bonuses);
                writer.Write(account.AccountType);
            }
        }

        public void CloseAccount(ulong id)
        {
            try
            {
                File.Delete(id.ToString());
            }
            catch
            {
                throw new Exception("Account doesn't exist");
            }
        }

        public void Withdraw(ulong id, int amount)
        {
            BankAccount account;
            try
            {
                using (var reader = new BinaryReader(File.OpenRead(id.ToString())))
                {
                    ulong s_id = reader.ReadUInt64();
                    string name = reader.ReadString();
                    string surname = reader.ReadString();
                    double balance = reader.ReadDouble();
                    double bonuses = reader.ReadDouble();
                    string accountType = reader.ReadString();
                    Assembly asm = Assembly.GetCallingAssembly();
                    Type type = asm.GetType(accountType);
                    object accTypeInstance = Activator.CreateInstance(type);
                    account = new BankAccount(s_id, new Person(name, surname),
                        (IAccountType)accTypeInstance, balance);
                }
                account.Withdraw(amount);
                using (var writer = new BinaryWriter(
                    File.Open(id.ToString(), FileMode.Create)))
                {
                    writer.Write(account.Id);
                    writer.Write(account.Owner.Name);
                    writer.Write(account.Owner.Surname);
                    writer.Write(account.Balance);
                    writer.Write(account.Bonuses);
                    writer.Write(account.AccountType);
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Account doesn't exist");
            }
        }

        public void Put(ulong id, int amount)
        {
            BankAccount account;
            try
            {
                using (var reader = new BinaryReader(File.OpenRead(id.ToString())))
                {
                    ulong s_id = reader.ReadUInt64();
                    string name = reader.ReadString();
                    string surname = reader.ReadString();
                    double balance = reader.ReadDouble();
                    double bonuses = reader.ReadDouble();
                    string accountType = reader.ReadString();
                    Assembly asm = Assembly.GetCallingAssembly();
                    Type type = asm.GetType(accountType);
                    object accTypeInstance = Activator.CreateInstance(type);
                    account = new BankAccount(s_id, new Person(name, surname),
                        (IAccountType)accTypeInstance, balance);
                }
                account.Put(amount);
                using (var writer = new BinaryWriter(
                    File.Open(id.ToString(), FileMode.Create)))
                {
                    writer.Write(account.Id);
                    writer.Write(account.Owner.Name);
                    writer.Write(account.Owner.Surname);
                    writer.Write(account.Balance);
                    writer.Write(account.Bonuses);
                    writer.Write(account.AccountType);
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Account doesn't exist");
            }
        }
        
    }
}
