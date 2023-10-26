namespace CosmeticsShop.Core
{
    using CosmeticsShop.Commands;
    using CosmeticsShop.Exceptions;
    using CosmeticsShop.Helpers;

    using System.Collections.Generic;

    public class CommandFactory
    {
        private const string CommandNotImplementedErrorMessage = "{} command is not implemented.";

        public ICommand CreateCommand(string commandTypeValue, List<string> parameters, CosmeticsRepository productRepository)
        {
            CommandType commandType = ValidationHelpers.ValidateCommandType(commandTypeValue);

            switch (commandType)
            {
                case CommandType.CreateCategory:
                    return new CreateCategory(parameters, productRepository);
                case CommandType.CreateProduct:
                    return new CreateProduct(parameters, productRepository);
                case CommandType.AddProductToCategory:
                    return new AddProductToCategory(parameters, productRepository);
                case CommandType.ShowCategory:
                    return new ShowCategory(parameters, productRepository);
                default:
                    throw new CommandNotImplementedException(string.Format(CommandNotImplementedErrorMessage, commandType));
            }
        }
    }
}
