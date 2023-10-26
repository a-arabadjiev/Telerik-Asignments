namespace CosmeticsShop.Commands
{
    using CosmeticsShop.Core;
    using CosmeticsShop.Models;

    using System.Collections.Generic;

    public class CreateProduct : BaseCommand
    {
        private const int ExpectedNumberOfParameters = 4;

        public CreateProduct(List<string> commandParameters, CosmeticsRepository cosmeticsRepository)
            : base(commandParameters, cosmeticsRepository)
        {
        }

        public override string Execute(List<string> parameters)
        {
            this.ValidateCommandParameters("CreateProduct", parameters.Count, ExpectedNumberOfParameters);

            string name = parameters[0];
            string brand = parameters[1];
            double price = this.ParseDoubleParameter(parameters[2], "price");
            GenderType gender = this.ParseGenderType(parameters[3]);
            this.CosmeticsRepository.CreateProduct(name, brand, price, gender);

            return $"Product with name {name} was created!";
        }
    }
}
