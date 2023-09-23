using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateToothpasteCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateToothpasteCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];

            this.ParseDecimalParameter(this.CommandParameters[2], "price");

            decimal price = decimal.Parse(this.CommandParameters[2]);
            GenderType gender = this.ParseGenderType(this.CommandParameters[3]);
            string ingredients = this.CommandParameters[4];

            return this.CreateToothpaste(name, brand, price, gender, ingredients);
        }

        private string CreateToothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException(string.Format($"Toothpaste with name {name} already exists!"));
            }

            this.Repository.CreateToothpaste(name, brand, price, gender, ingredients);

            return $"Toothpaste with name {name} was created!";
        }
    }
}
