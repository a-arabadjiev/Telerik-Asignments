namespace CosmeticsShop.Exceptions
{
    using System;

    public class InvalidUserInputException : ApplicationException
    {
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}
