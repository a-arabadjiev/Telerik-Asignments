using System;
using System.Text;

namespace Cosmetics.Models
{
    public class Product
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        private const int GenderMinValue = 0;
        private const int GenderMaxValue = 2;

        private string name;
        private string brand;
        private double price;
        private GenderType gender;

        // "Each product in the system has name, brand, price and gender."

        public Product(string name, string brand, double price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                this.price = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product name should be between 3 and 10 characters long.");
                }

                if (value.Length < NameMinLength || value.Length > NameMaxLength) 
                {
                    throw new ArgumentException("Product name should be between 3 and 10 characters long.");
                }
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Brand name should be between 2 and 10 characters long.");
                }

                if (value.Length < BrandMinLength || value.Length > BrandMaxLength)
                {
                    throw new ArgumentException("Brand name should be between 2 and 10 characters long.");
                }
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                if ((int)value < GenderMinValue || (int)value > GenderMaxValue)
                {
                    throw new ArgumentException("Gender for product must be either Men, Women or Unisex.");
                }

                this.gender = value;
            }
        }

        public string Print()
        {
            // Format:
            // #[Name] [Brand]
            // #Price: [Price]
            // #Gender: [Gender]

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" #{this.Name} {this.Brand}");
            sb.AppendLine($" #Price: {this.Price}");
            sb.AppendLine($" #Gender: {this.Gender}");

            return sb.ToString().TrimEnd();
        }

        public override bool Equals(object p)
        {
            if (p == null || !(p is Product))
            {
                return false;
            }

            if (this == p)
            {
                return true;
            }

            Product otherProduct = (Product)p;

            return this.Price == otherProduct.Price
                    && this.Name == otherProduct.Name
                    && this.Brand == otherProduct.Brand
                    && this.Gender == otherProduct.Gender;
        }
    }
}