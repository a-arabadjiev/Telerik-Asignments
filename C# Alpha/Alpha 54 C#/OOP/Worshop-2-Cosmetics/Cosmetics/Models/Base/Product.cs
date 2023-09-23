namespace Cosmetics.Models.Base
{
    using Cosmetics.Helpers;
    using Cosmetics.Models.Enums;
    using Cosmetics.Models.Contracts;

    using System.Text;

    public abstract class Product : IProduct
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
        }

        public virtual string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                ValidationHelper.ValidateStringLength(value, NameMinLength, NameMaxLength);

                name = value;
            }
        }

        public virtual string Brand
        {
            get
            {
                return brand;
            }
            protected set
            {
                ValidationHelper.ValidateStringLength(value, BrandMinLength, BrandMaxLength);

                brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                ValidationHelper.ValidateNonNegative(value, "Price");

                price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return gender;
            }
            private set
            {
                ValidationHelper.ValidateEnumValue((int)value, typeof(GenderType));

                gender = value;
            }
        }

        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"#{Name} {Brand}");
            sb.AppendLine($" #Price: {Price}");
            sb.AppendLine($" #Gender: {Gender}");

            return sb.ToString();
        }
    }
}
