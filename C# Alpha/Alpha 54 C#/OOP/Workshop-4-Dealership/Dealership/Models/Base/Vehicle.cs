namespace Dealership.Models.Base
{
    using Dealership.Models.Contracts;

    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicle : IVehicle

    {
        private const int MakeMinLength = 2;
        private const int MakeMaxLength = 15;
        private const string InvalidMakeError = "Make must be between 2 and 15 characters long!";
        private const int ModelMinLength = 1;
        private const int ModelMaxLength = 15;
        private const string InvalidModelError = "Model must be between 1 and 15 characters long!";
        private const decimal MinPrice = 0.0m;
        private const decimal MaxPrice = 1000000.0m;
        private const string InvalidPriceError = "Price must be between 0.0 and 1000000.0!";

        private string make;
        private string model;
        private decimal price;

        private readonly IList<IComment> comments;

        protected Vehicle(VehicleType type, string make, string model, decimal price)
        {
            this.Type = type;
            this.Make = make;
            this.Model = model;
            this.Price = price;

            this.comments = new List<IComment>();
        }

        public VehicleType Type { get; private set; }

        public string Make 
        { 
            get
            {
                return this.make;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, MakeMinLength, MakeMaxLength, InvalidMakeError);
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, ModelMinLength, ModelMaxLength, InvalidModelError);
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                Validator.ValidateDecimalRange(value, MinPrice, MaxPrice, InvalidPriceError);
                this.price = value;
            }
        }

        public abstract int Wheels { get; }

        public IList<IComment> Comments => new List<IComment>(this.comments);

        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
        }

        public void RemoveComment(IComment comment)
        {
            this.comments.Remove(comment);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" {this.Type}:");
            sb.AppendLine($"  Make: {this.Make}");
            sb.AppendLine($"  Model: {this.Model}");
            sb.AppendLine($"  Wheels: {this.Wheels}");
            sb.AppendLine($"  Price: ${this.Price}");

            return sb.ToString();
        }
    }
}
