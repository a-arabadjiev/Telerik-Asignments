namespace Dealership.Models
{
    using Dealership.Models.Base;

    using Dealership.Models.Contracts;

    public class Car : Vehicle, ICar
    {
        private const int MinSeats = 1;
        private const int MaxSeats = 10;
        private const string InvalidSeatsError = "Seats must be between 1 and 10!";

        private const int wheels = 4;

        private int seats;

        public Car(string make, string model, decimal price, int seats) 
            : base(VehicleType.Car, make, model, price)
        {
            this.Seats = seats;
        }

        public override int Wheels => wheels;

        public int Seats
        {
            get 
            { 
                return this.seats; 
            }
            protected set
            {
                Validator.ValidateIntRange(value, MinSeats, MaxSeats, InvalidSeatsError);
                this.seats = value;
            }
        }

        public override string ToString()
        {
            string carLine = $"  Seats: {this.Seats}";

            return base.ToString() + carLine;
        }
    }
}
