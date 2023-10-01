namespace Agency.Models.Base
{
    using Agency.Helpers;
    using Agency.Models.Contracts;

    using System.Text;

    public abstract class Vehicle : IVehicle
    {
        private const int PassengerCapacityMinValue = 1;
        private const int PassengerCapacityMaxValue = 800;
        private const double PricePerKilometerMinValue = 0.10;
        private const double PricePerKilometerMaxValue = 2.50;

        protected int passengerCapacity;
        protected double pricePerKilometer;

        protected Vehicle(int id, int passengerCapacity, double pricePerKilometer)
        {
            this.Id = id;
            this.PassengerCapacity = passengerCapacity;
            this.PricePerKilometer = pricePerKilometer;
        }

        public virtual int PassengerCapacity
        {
            get
            {
                return this.passengerCapacity;
            }
            protected set
            {
                ValidationHelpers.ValidateVehiclePassengerCapacity(value, PassengerCapacityMinValue, PassengerCapacityMaxValue);
                this.passengerCapacity = value;
            }
        }

        public virtual double PricePerKilometer
        {
            get
            {
                return this.pricePerKilometer;
            }
            protected set
            {
                ValidationHelpers.ValidateVehiclePricePerKm(value, PricePerKilometerMinValue, PricePerKilometerMaxValue);
                this.pricePerKilometer = value;
            }
        }
        public int Id { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} ----");
            sb.AppendLine($"Passenger capacity: {this.PassengerCapacity}");
            sb.AppendLine($"Price per kilometer: {this.PricePerKilometer:F2}");

            return sb.ToString();
        }
    }
}
