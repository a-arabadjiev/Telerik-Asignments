namespace CosmeticsShop.Commands
{
    using CosmeticsShop.Core;
    using CosmeticsShop.Models;

    using System.Collections.Generic;

    public class ShowCategory : BaseCommand
    {
        private const int ExpectedNumberOfParameters = 1;

        public ShowCategory(List<string> commandParameters, CosmeticsRepository cosmeticsRepository)
            : base(commandParameters, cosmeticsRepository)
        {
        }

        public override string Execute(List<string> parameters)
        {
            this.ValidateCommandParameters("ShowCategory", parameters.Count, ExpectedNumberOfParameters);
            string categoryName = parameters[0];

            Category category = this.CosmeticsRepository.FindCategoryByName(categoryName);

            return category.Print();
        }
    }
}
