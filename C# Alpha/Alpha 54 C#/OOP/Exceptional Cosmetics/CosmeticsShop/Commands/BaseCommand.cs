namespace CosmeticsShop.Commands
{
    using CosmeticsShop.Core;
    using CosmeticsShop.Exceptions;
    using CosmeticsShop.Models;

    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public abstract class BaseCommand : ICommand
    {
        // Messages
        private const string CommandInvalidParametersAmountErrorMessage = "{0} command expects {1} parameters.";
        private const string InvalidPriceParameterErrorMessage = "Third parameter should be price (real number).";
        private const string InvalidGenderTypeParameterErrorMessage = "Forth parameter should be one of Men, Women or Unisex.";

        protected BaseCommand(CosmeticsRepository repository)
            : this(new List<string>(), repository)
        {
        }

        protected BaseCommand(List<string> commandParameters, CosmeticsRepository cosmeticsRepository)
        {
            this.CommandParameters = commandParameters;
            this.CosmeticsRepository = cosmeticsRepository;
        }

        protected CosmeticsRepository CosmeticsRepository { get; }

        protected List<string> CommandParameters { get; }

        public abstract string Execute(List<string> parameters);

        // Validation methods
        protected double ParseDoubleParameter(string value, string parameterName)
        {
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            throw new InvalidUserInputException(InvalidPriceParameterErrorMessage);
        }

        protected GenderType ParseGenderType(string value)
        {
            if (Enum.TryParse(value, true, out GenderType result))
            {
                return result;
            }
            throw new InvalidUserInputException(InvalidGenderTypeParameterErrorMessage);
        }

        protected void ValidateCommandParameters(string commandName, int parametersCount, int expectedNumberOfParameters)
        {
            if (parametersCount < expectedNumberOfParameters)
            {
                throw new InvalidUserInputException(string.Format(CommandInvalidParametersAmountErrorMessage, commandName, expectedNumberOfParameters));
            }
        }
    }
}
