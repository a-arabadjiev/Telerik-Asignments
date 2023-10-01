namespace Agency.Helpers
{
    using Agency.Exceptions;

    public class ValidationHelpers
    {
        // Vehicle error messages
        private const string VehicleInvalidPassengerCapacityErrorMessage = "A vehicle with less than 1 passengers or more than 800 passengers cannot exist!";
        private const string VehicleInvalidPricePerKmErrorMessage = "A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!";

        // Child vehicle error messages
        private const string ChildVehicleInvalidPassengerCapacityErrorMessage = "A {0} cannot have less than {1} passengers or more than {2} passengers.";
        private const string TrainInvalidCartsAmountErrorMessage = "A train cannot have less than 1 cart or more than 15 carts.";

        // Journey error messages
        private const string JourneyInvalidStringLengthErrorMessage = "The length of {0} must be between 5 and 25 symbols.";
        private const string JourneyInvalidDistanceValue = "The Distance cannot be less than 5 or more than 5000 kilometers.";

        // Ticket error messages
        private const string TicketNegativeAdministrativeCostsErrorMessage = "Value of 'costs' must be a positive number. Actual value: {0:F2}.";

        // Vehicle methods
        public static void ValidateVehiclePassengerCapacity(int capacity, int minCapacity, int maxCapacity)
        {
            if (capacity < minCapacity || capacity > maxCapacity)
            {
                throw new InvalidUserInputException(VehicleInvalidPassengerCapacityErrorMessage);
            }
        }

        public static void ValidateVehiclePricePerKm(double pricePerKm, double minPrice, double maxPrice)
        {
            if (pricePerKm < minPrice || pricePerKm > maxPrice) 
            {
                throw new InvalidUserInputException(VehicleInvalidPricePerKmErrorMessage);
            }
        }

        // Child vehicle methods
        public static void ValidateChildVehiclePassengerCapacity(string vehicleType,int capacity, int minCapacity, int maxCapacity)
        {
            if (capacity < minCapacity || capacity > maxCapacity)
            {
                throw new InvalidUserInputException(string.Format(ChildVehicleInvalidPassengerCapacityErrorMessage ,vehicleType, minCapacity, maxCapacity));
            }
        }

        public static void ValidateTrainCartsAmount(int totalCarts, int minCarts, int maxCarts)
        {
            if (totalCarts < minCarts || totalCarts > maxCarts)
            {
                throw new InvalidUserInputException(TrainInvalidCartsAmountErrorMessage);
            }
        }

        // Journey methods
        public static void ValidateJourneyStringLength(string propertyType, int length, int minLength, int maxLength)
        {
            if (length < minLength || length > maxLength) 
            {
                throw new InvalidUserInputException(string.Format(JourneyInvalidStringLengthErrorMessage, propertyType));
            }
        }

        public static void ValidateJourneyDistanceValue(int value, int minValue, int maxValue)
        {
            if (value < minValue || value > maxValue)
            {
                throw new InvalidUserInputException(JourneyInvalidDistanceValue);
            }
        }

        // Ticket methods
        public static void ValidateTicketAdministrativeCostsNotNegative(double value)
        {
            if (value < 0)
            {
                throw new InvalidUserInputException(string.Format(TicketNegativeAdministrativeCostsErrorMessage, value));
            }
        }
    }
}
