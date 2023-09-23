namespace Cosmetics.Commands
{
    using Cosmetics.Core.Contracts;
    using Cosmetics.Helpers;
    using Cosmetics.Models.Enums;

    using System;
    using System.Collections.Generic;

    public class CreateCreamCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateCreamCommand(IList<string> parameters, IRepository repository)
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
            ScentType scent = this.ParseScentType(this.CommandParameters[4]);

            return this.CreateCream(name, brand, price, gender, scent);
        }

        private string CreateCream(string name, string brand, decimal price, GenderType gender, ScentType scent)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException(string.Format($"Cream with name {name} already exists!"));
            }

            this.Repository.CreateCream(name, brand, price, gender, scent);

            return $"Cream with name {name} was created!";
        }
    }
}
