namespace CosmeticsShop.Exceptions
{
    using System;

    public class CommandNotImplementedException : ApplicationException
    {
        public CommandNotImplementedException(string message) 
            : base(message)
        {
        }
    }
}
