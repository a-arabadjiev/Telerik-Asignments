namespace CosmeticsShop.Core
{
    using CosmeticsShop.Exceptions;
    using CosmeticsShop.Models;

    using System.Collections.Generic;


    public class CosmeticsRepository
    {
        // Error messages
        private const string EntityAlreadyExistsErrorMessage = "{0} {1} already exist.";
        private const string EntityDoesNotExistErrorMessage = "{0} {1} does not exist.";

        private readonly List<Category> categories;
        private readonly List<Product> products;

        public CosmeticsRepository()
        {
            this.categories = new List<Category>();
            this.products = new List<Product>();
        }

        public List<Category> Categories
        {
            get
            {
                return this.categories;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public void CreateCategory(string categoryName)
        {
            if (this.CategoryExist(categoryName)) 
            {
                throw new EntityAlreadyExistsException(string.Format(EntityAlreadyExistsErrorMessage, "Category", categoryName));
            }

            this.categories.Add(new Category(categoryName));
        }

        public void CreateProduct(string name, string brand, double price, GenderType gender)
        {
            if (this.ProductExist(name))
            {
                throw new EntityAlreadyExistsException(string.Format(EntityAlreadyExistsErrorMessage, "Product", name));
            }

            this.products.Add(new Product(name, brand, price, gender));
        }

        public bool CategoryExist(string name)
        {
            foreach (var category in this.categories)
            {
                if (category.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public Category FindCategoryByName(string name)
        {
            foreach (var category in this.categories)
            {
                if (category.Name == name)
                {
                    return category;
                }
            }

            throw new EntityDoesNotExistException(string.Format(EntityDoesNotExistErrorMessage, "Category", name));
        }

        public bool ProductExist(string name)
        {
            foreach (var product in this.products)
            {
                if (product.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public Product FindProductByName(string name)
        {
            foreach (var product in this.products)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }

            throw new EntityDoesNotExistException(string.Format(EntityDoesNotExistErrorMessage, "Product", name));
        }
    }
}
