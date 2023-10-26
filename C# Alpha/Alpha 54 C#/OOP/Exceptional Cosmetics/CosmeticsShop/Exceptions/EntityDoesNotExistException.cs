namespace CosmeticsShop.Exceptions
{
    using System;

    public class EntityDoesNotExistException : ApplicationException
    {
        public EntityDoesNotExistException(string message) 
            : base(message)
        {
        }
    }
}
