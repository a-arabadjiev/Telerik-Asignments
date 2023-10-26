namespace CosmeticsShop.Helpers
{
    using CosmeticsShop.Commands;
    using CosmeticsShop.Exceptions;
    using CosmeticsShop.Models;

    using System;

    public class ValidationHelpers
    {
        // Messages
        private const string StringParameterLengthErrorMessage = "{0} should be between {1} and {2} symbols.";
        private const string PriceCannotBeNegativeErrorMessage = "Price can't be negative.";
        private const string InvalidCommandErrorMessage = "Command {0} is not supported.";

        // Methods
        public static void ValidateStringParameterLength(string parameterType, int length, int minLength, int maxLength)
        {
            if (length < minLength || length > maxLength)
            {
                throw new InvalidUserInputException(string.Format(StringParameterLengthErrorMessage, parameterType, minLength, maxLength));
            }
        }

        public static void ValidatePriceNotNegative(double price)
        {
            if (price < 0) 
            {
                throw new InvalidUserInputException(PriceCannotBeNegativeErrorMessage);
            }
        }

        public static CommandType ValidateCommandType(string commandType)
        {
            if (Enum.TryParse(commandType, true, out CommandType result))
            {
                return result;
            }
            throw new InvalidUserInputException(string.Format(InvalidCommandErrorMessage, commandType));
        }
    }
}
