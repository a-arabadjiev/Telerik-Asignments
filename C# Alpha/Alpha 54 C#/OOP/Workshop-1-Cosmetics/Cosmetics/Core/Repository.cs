using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Core
{
    public class Repository : IRepository
    {
        private readonly List<Product> products;
        private readonly List<Category> categories;
        private readonly ShoppingCart shoppingCart;

        public Repository()
        {
            this.products = new List<Product>();
            this.categories = new List<Category>();

            this.shoppingCart = new ShoppingCart();
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                return this.shoppingCart;
            }
        }

        public List<Category> Categories
        {
            get
            {
                return new List<Category>(this.categories);
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }

        public Product FindProductByName(string productName)
        {
            Product product = this.Products.FirstOrDefault(p => p.Name == productName);

            if (product == null)
            {
                throw new ArgumentException($"Product {productName} does not exist");
            }

            return product;
        }

        public Category FindCategoryByName(string categoryName)
        {
            Category category = this.Categories.FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                throw new ArgumentException($"Category {categoryName} does not exist");
            }

            return category;
        }

        public void CreateCategory(string categoryName)
        {
            Category category = new Category(categoryName);
            this.categories.Add(category);
        }

        public void CreateProduct(string name, string brand, double price, GenderType gender)
        {
            Product product = new Product(name, brand, price, gender);
            this.products.Add(product);
        }

        public bool CategoryExist(string categoryName)
        {
            Category category = this.Categories.FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                return false;
            }
            return true;
        }

        public bool ProductExist(string productName)
        {
            Product product = this.Products.FirstOrDefault(p => p.Name == productName);
            
            if (product == null) 
            {
                return false;
            }
            return true;
        }
    }
}
