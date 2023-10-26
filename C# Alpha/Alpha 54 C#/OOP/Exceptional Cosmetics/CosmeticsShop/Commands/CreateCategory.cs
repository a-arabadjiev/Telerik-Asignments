using CosmeticsShop.Core;

using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class CreateCategory : BaseCommand
    {
        private const int ExpectedNumberOfParameters = 1;

        public CreateCategory(List<string> commandParameters, CosmeticsRepository cosmeticsRepository)
            : base(commandParameters, cosmeticsRepository)
        {
        }

        public override string Execute(List<string> parameters)
        {
            base.ValidateCommandParameters("CreateCategory", parameters.Count, ExpectedNumberOfParameters);
            string categoryName = parameters[0];

            this.CosmeticsRepository.CreateCategory(categoryName);

            return $"Category with name {categoryName} was created!";
        }
    }
}
