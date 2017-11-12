using System;

namespace Day9
{
    public class InvalidAccountIdException : Exception
    {
        public InvalidAccountIdException(ulong id) : base("Account not found")
        {
            this.Id = id;
        }

        public ulong Id { get; }
    }
}
