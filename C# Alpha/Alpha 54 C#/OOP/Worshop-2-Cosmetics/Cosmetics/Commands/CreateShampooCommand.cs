using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 6;

        public CreateShampooCommand(IList<string> parameters, IRepository repository)
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

            this.ParseIntParameter(this.CommandParameters[4], "millilitres");

            int millilitres = int.Parse(this.CommandParameters[4]);
            UsageType usage = this.ParseUsageType(this.CommandParameters[5]);

            return this.CreateShampoo(name, brand, price, gender, millilitres, usage);
        }

        private string CreateShampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException(string.Format($"Shampoo with name {name} already exists!"));
            }

            this.Repository.CreateShampoo(name, brand, price, gender, millilitres, usage);

            return $"Shampoo with name {name} was created!";
        }
    }
}
