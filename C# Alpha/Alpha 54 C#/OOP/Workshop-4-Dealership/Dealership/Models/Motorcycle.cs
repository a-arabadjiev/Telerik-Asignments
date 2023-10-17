namespace Dealership.Models
{
    using Dealership.Models.Base;
    using Dealership.Models.Contracts;

    public class Motorcycle : Vehicle, IMotorcycle
    {
        private const int CategoryMinLength = 3;
        private const int CategoryMaxLength = 10;
        private const string InvalidCategoryError = "Category must be between 3 and 10 characters long!";

        private const int wheels = 2;

        private string category;

        public Motorcycle(string make, string model, decimal price, string category) 
            : base(VehicleType.Motorcycle, make, model, price)
        {
            this.Category = category;
        }

        public override int Wheels => wheels;

        public string Category
        {
            get
            {
                return this.category;
            }
            protected set
            {
                Validator.ValidateIntRange(value.Length, CategoryMinLength, CategoryMaxLength, InvalidCategoryError);
                this.category = value;
            }
        }

        public override string ToString()
        {
            string motorcycleLine = $"  Category: {this.Category}";

            return base.ToString() + motorcycleLine;
        }
    }
}
