namespace Agency.Models
{
    using Agency.Models.Base;
    using Agency.Models.Contracts;

    using System;

    public class Airplane : Vehicle, IAirplane
    {
        //private const int PassengerCapacityMinValue = 1;
        //private const int PassengerCapacityMaxValue = 800;
        //private const double PricePerKilometerMinValue = 0.10;
        //private const double PricePerKilometerMaxValue = 2.50;

        public Airplane(int id, int passengerCapacity, double pricePerKilometer, bool isLowCost)
            : base(id, passengerCapacity, pricePerKilometer)
        {
            this.IsLowCost = isLowCost;
        }

        public bool IsLowCost { get; private set; }

        public override string ToString()
        {
            string baseToString = base.ToString();
            string airplaneLine = $"Is low-cost: {this.IsLowCost}";

            return baseToString + airplaneLine;
        }
    }
}
