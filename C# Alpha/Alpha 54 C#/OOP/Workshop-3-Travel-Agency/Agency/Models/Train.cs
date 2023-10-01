namespace Agency.Models
{
    using Agency.Helpers;
    using Agency.Models.Base;
    using Agency.Models.Contracts;

    using System;

    public class Train : Vehicle, ITrain
    {
        private const int PassengerCapacityMinValue = 30;
        private const int PassengerCapacityMaxValue = 150;
        private const int CartsMinValue = 1;
        private const int CartsMaxValue = 15;

        private int carts;

        public Train(int id, int passengerCapacity, double pricePerKilometer, int carts) 
            : base(id, passengerCapacity, pricePerKilometer)
        {
            this.Carts = carts;
        }

        public override int PassengerCapacity 
        {   
            get
            {
                return base.PassengerCapacity;
            }
            protected set
            {
                ValidationHelpers.ValidateChildVehiclePassengerCapacity("train", value, PassengerCapacityMinValue, PassengerCapacityMaxValue);
                base.passengerCapacity = value;
            }
        }

        public int Carts
        {
            get
            {
                return this.carts;
            }
            private set
            {
                ValidationHelpers.ValidateTrainCartsAmount(value, CartsMinValue, CartsMaxValue);
                this.carts = value;
            }
        }

        public override string ToString()
        {
            string baseToString = base.ToString();
            string trainLine = $"Carts amount: {this.Carts}";

            return baseToString + trainLine;
        }
    }
}
