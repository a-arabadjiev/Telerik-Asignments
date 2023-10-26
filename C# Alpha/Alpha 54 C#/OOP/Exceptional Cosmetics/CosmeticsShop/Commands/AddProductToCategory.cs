namespace CosmeticsShop.Commands
{
    using CosmeticsShop.Core;
    using CosmeticsShop.Models;

    using System.Collections.Generic;

    public class AddProductToCategory : BaseCommand
    {
        private const int ExpectedNumberOfParameters = 2;

        public AddProductToCategory(List<string> commandParameters, CosmeticsRepository cosmeticsRepository)
            : base(commandParameters, cosmeticsRepository)
        {
        }

        public override string Execute(List<string> parameters)
        {
            base.ValidateCommandParameters("AddProductToCategory", parameters.Count, ExpectedNumberOfParameters);

            string categoryName = parameters[0];

            string productName = parameters[1];

            Category category = this.CosmeticsRepository.FindCategoryByName(categoryName);
            Product product = this.CosmeticsRepository.FindProductByName(productName);

            category.AddProduct(product);

            return $"Product {productName} added to category {categoryName}!";
        }
    }
}
