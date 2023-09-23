namespace Cosmetics.Models
{
    using Cosmetics.Models.Contracts;
    using Cosmetics.Helpers;
    using Cosmetics.Models.Base;
    using Cosmetics.Models.Enums;

    using System.Text;

    public class Shampoo : Product, IShampoo
    {
        private int millilitres;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
            :base(name, brand, price, gender)
        {
            this.Millilitres = millilitres;
            this.Usage = usage;
        }

        public int Millilitres
        {
            get 
            { 
                return this.millilitres; 
            } 
            private set 
            {
                ValidationHelper.ValidateNonNegative(value, "Millilitres");

                this.millilitres = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            private set
            {
                ValidationHelper.ValidateEnumValue((int)value, typeof(UsageType));

                this.usage = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder(base.Print());

            sb.AppendLine($" #Milliliters: {this.Millilitres}");
            sb.AppendLine($" #Usage: {this.Usage}");
            sb.AppendLine("===");

            return sb.ToString();
        }
    }
}
