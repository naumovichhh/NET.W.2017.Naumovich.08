using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class AccountTypeNotFoundException : Exception
    {
        public AccountTypeNotFoundException(ulong id) : base("Account type not found")
        {
            this.Id = id;
        }

        public ulong Id { get; }
    }
}
