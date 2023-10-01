namespace Agency.Models
{
    using Agency.Helpers;
    using Agency.Models.Contracts;

    using System.Text;

    public class Ticket : ITicket
    {
        private double administrativeCosts;

        public Ticket(int id, IJourney journey, double administrativeCosts)
        {
            this.Id = id;
            this.Journey = journey;
            this.AdministrativeCosts = administrativeCosts;
        }

        public double AdministrativeCosts
        {
            get
            {
                return this.administrativeCosts;
            }
            private set
            {
                ValidationHelpers.ValidateTicketAdministrativeCostsNotNegative(value);
                this.administrativeCosts = value;
            }
        }

        public IJourney Journey { get; private set; }

        public int Id { get; private set; }

        public double CalculatePrice()
        {
            return this.AdministrativeCosts * this.Journey.CalculatePrice();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Ticket ----");
            sb.AppendLine($"Destination: {this.Journey.Destination}");
            sb.Append($"Price: {this.CalculatePrice():F2}");

            return sb.ToString();
        }
    }
}
