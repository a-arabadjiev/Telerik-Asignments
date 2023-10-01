namespace Agency.Models
{
    using Agency.Helpers;
    using Agency.Models.Base;
    using Agency.Models.Contracts;

    using System;

    public class Bus : Vehicle, IBus
    {
        private const int PassengerCapacityMinValue = 10;
        private const int PassengerCapacityMaxValue = 50;
        //private const double PricePerKilometerMinValue = 0.10;
        //private const double PricePerKilometerMaxValue = 2.50;
        
        public Bus(int id, int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
            : base(id, passengerCapacity, pricePerKilometer)
        {
            this.HasFreeTv = hasFreeTv;
        }

        public override int PassengerCapacity
        {
            get
            {
                return base.PassengerCapacity;
            }
            protected set
            {
                ValidationHelpers.ValidateChildVehiclePassengerCapacity("bus", value, PassengerCapacityMinValue, PassengerCapacityMaxValue);
                base.passengerCapacity = value;
            }
        }

        public bool HasFreeTv { get; private set; }

        public override string ToString()
        {
            string baseToString = base.ToString();
            string busLine = $"Has free TV: {this.HasFreeTv}";

            return baseToString + busLine;
        }
    }
}
