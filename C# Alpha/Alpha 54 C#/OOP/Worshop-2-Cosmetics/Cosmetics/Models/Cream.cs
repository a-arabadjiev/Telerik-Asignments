namespace Cosmetics.Models
{
    using Cosmetics.Helpers;
    using Cosmetics.Models.Base;
    using Cosmetics.Models.Contracts;
    using Cosmetics.Models.Enums;

    using System.Text;

    public class Cream : Product, ICream
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 15;
        private const int BrandMinLength = 3;
        private const int BrandMaxLength = 15;

        private string name;
        private string brand;
        private ScentType scent;

        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent) 
            : base(name, brand, price, gender)
        {
            this.Scent = scent;
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                ValidationHelper.ValidateStringLength(value, NameMinLength, NameMaxLength);

                this.name = value; 
            }
        }
        public override string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {
                ValidationHelper.ValidateStringLength(value, BrandMinLength, BrandMaxLength);

                this.brand = value;
            }
        }

        public ScentType Scent
        {
            get
            {
                return this.scent;
            }
            private set
            {
                ValidationHelper.ValidateEnumValue((int)value, typeof(ScentType));

                this.scent = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder(base.Print());

            sb.AppendLine($" #Scent: {this.Scent}");
            sb.AppendLine("===");

            return sb.ToString();
        }
    }
}
