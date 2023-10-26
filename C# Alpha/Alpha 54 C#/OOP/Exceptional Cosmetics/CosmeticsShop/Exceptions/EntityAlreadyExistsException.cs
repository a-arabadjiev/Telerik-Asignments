namespace CosmeticsShop.Exceptions
{
    using System;

    public class EntityAlreadyExistsException : ApplicationException
    {
        public EntityAlreadyExistsException(string message) 
            : base(message)
        {
        }
    }
}
