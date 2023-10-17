namespace Dealership.Models
{
    using Dealership.Models.Base;
    using Dealership.Models.Contracts;

    public class Truck : Vehicle, ITruck
    {
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;
        public const string InvalidCapacityError = "Weight capacity must be between 1 and 100!";

        private const int wheels = 8;

        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) 
            : base(VehicleType.Truck, make, model, price)
        {
            this.WeightCapacity = weightCapacity;
        }

        public override int Wheels => wheels;

        public int WeightCapacity
        {
            get 
            { 
                return this.weightCapacity; 
            }
            private set 
            {
                Validator.ValidateIntRange(value, MinCapacity, MaxCapacity, InvalidCapacityError);
                this.weightCapacity = value; 
            }
        }

        public override string ToString()
        {
            string truckLine = $"  Weight Capacity: {this.WeightCapacity}t";

            return base.ToString() + truckLine;
        }
    }
}
