using System;
using System.Text;
using Agency.Helpers;
using Agency.Models.Contracts;

namespace Agency.Models
{
    public class Journey : IJourney
    {
        private const int StartLocationMinLength = 5;
        private const int StartLocationMaxLength = 25;
        private const int DestinationMinLength = 5;
        private const int DestinationMaxLength = 25;
        private const int DistanceMinValue = 5;
        private const int DistanceMaxValue = 5000;

        private string startLocation;
        private string destination;
        private int distance;

        public Journey(int id, string from, string to, int distance, IVehicle vehicle)
        {
            this.Id = id;
            this.StartLocation = from;
            this.Destination = to;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string StartLocation
        {
            get 
            { 
                return this.startLocation; 
            }
            private set
            {
                ValidationHelpers.ValidateJourneyStringLength("StartLocation", value.Length, StartLocationMinLength, StartLocationMaxLength);
                this.startLocation = value;
            }
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            private set
            {
                ValidationHelpers.ValidateJourneyStringLength("Destination", value.Length, DestinationMinLength, DestinationMaxLength);
                this.destination = value;
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            private set
            {
                ValidationHelpers.ValidateJourneyDistanceValue(value, DistanceMinValue, DistanceMaxValue);
                this.distance = value;
            }
        }

        public IVehicle Vehicle { get; private set; }

        public int Id { get; private set; }

        public double CalculatePrice()
        {
            return this.Distance * this.Vehicle.PricePerKilometer;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Journey ----");
            sb.AppendLine($"Start location: {this.StartLocation}");
            sb.AppendLine($"Destination: {this.Destination}");
            sb.AppendLine($"Distance: {this.Distance}");
            sb.Append($"Travel costs: {this.CalculatePrice():F2}");

            return sb.ToString();
        }
    }
}
