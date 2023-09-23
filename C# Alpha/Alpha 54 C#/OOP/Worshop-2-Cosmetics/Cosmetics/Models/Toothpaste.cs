namespace Cosmetics.Models
{
    using Cosmetics.Helpers;
    using Cosmetics.Models.Base;
    using Cosmetics.Models.Contracts;
    using Cosmetics.Models.Enums;

    using System.Text;

    public class Toothpaste : Product, IToothpaste
    {
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;
        }

        public string Ingredients 
        { 
            get
            {
                return this.ingredients;
            }
            private set
            {
                ValidationHelper.ValidateStringNotNull(value, "Ingredients");

                this.ingredients = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder(base.Print());

            sb.AppendLine($" #Ingredients: {string.Join(", ", this.Ingredients.Split(','))}");
            sb.AppendLine("===");

            return sb.ToString();
        }
    }
}
