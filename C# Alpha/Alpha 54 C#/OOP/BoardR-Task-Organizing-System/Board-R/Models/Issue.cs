namespace Board_R.Models
{
    using Board_R.Models.Base;
    using Board_R.Models.Enums;

    public class Issue : BoardItem
    {
        private const Status initialStatus = Status.Open;
        private const Status finalStatus = Status.Verified;

        private readonly string description;

        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate)
        {
            this.description = description ?? "No description";
            this.Status = initialStatus;

            this.AddEvent($"Created Issue: '{this.Title}', [{this.Status}|{dueDate:d}]. {this.description}");
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public override Status Status { get; protected set; }

        public override void AdvanceStatus()
        {
            if (this.Status != finalStatus)
            {
                this.AddEvent($"Issue status set to {finalStatus}");

                this.Status = finalStatus;
            }
            else
            {
                this.AddEvent($"Issue status already {finalStatus}");
            }
        }

        public override void RevertStatus()
        {
            if (this.Status != initialStatus)
            {
                this.AddEvent($"Issue status set to {initialStatus}");

                this.Status = initialStatus;
            }
            else
            {
                this.AddEvent($"Issue status already {initialStatus}");
            }
        }
    }
}
