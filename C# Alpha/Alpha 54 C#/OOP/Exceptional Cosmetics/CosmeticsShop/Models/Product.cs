using CosmeticsShop.Helpers;
using System.Text;

namespace CosmeticsShop.Models
{
    public class Product
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private double price;
        private readonly GenderType gender;

        public Product(string name, string brand, double price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                ValidationHelpers.ValidateStringParameterLength("Product name", value.Length, NameMinLength, NameMaxLength);
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                ValidationHelpers.ValidateStringParameterLength("Product brand", value.Length, BrandMinLength, BrandMaxLength);
                this.brand = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                ValidationHelpers.ValidatePriceNotNegative(value);
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
        }

        public string Print()
        {
            var strBulder = new StringBuilder();
            strBulder.AppendLine($"#{this.name} {this.brand}");
            strBulder.AppendLine($" #Price: ${this.price}");
            strBulder.AppendLine($" #Gender: {this.gender}");

            return strBulder.ToString().Trim();
        }
    }
}
