using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> products = new List<Product>();

        public ShoppingCart()
        {
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
                throw new ArgumentException("Unable to remove product that doesn't exist in shopping cart.");
            }
        }

        public bool ContainsProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product is invalid.");
            }

            bool hasItemBeenFound = this.products.Contains(product);

            return hasItemBeenFound;
        }

        public double TotalPrice()
        {
            double sum = this.products.Sum(p => p.Price);

            return sum;
        }
    }
}
