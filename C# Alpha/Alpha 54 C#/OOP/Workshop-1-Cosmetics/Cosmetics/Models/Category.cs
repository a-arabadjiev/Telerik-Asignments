using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmetics.Models
{
    public class Category
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 15;

        private string name;
        private readonly List<Product> products = new List<Product>();

        public Category(string name)
        {
            this.Name = name;
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
                    throw new ArgumentException("Category name should be between 2 and 15 characters long.");
                }

                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException("Category name should be between 2 and 15 characters long.");
                }
                this.name = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product is invalid.");
            }

            this.products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product is invalid.");
            }

            bool hasItemBeenRemoved = this.products.Remove(product);

            if (!hasItemBeenRemoved)
            {
                throw new ArgumentException("Unable to remove product that doesn't exist in category.");
            }
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"#Category: {this.Name}");

            if (this.Products.Count == 0) 
            {
                sb.AppendLine(" #No products in this category");
            }
            else
            {
                foreach (Product product in this.Products)
                {
                    sb.AppendLine(product.Print());
                    sb.AppendLine(" ===");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

