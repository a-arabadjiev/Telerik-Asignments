namespace Board_R.Models
{
    using Board_R.Models.Base;
    using Board_R.Models.Enums;

    public class Task : BoardItem
    {
        private const Status initialStatus = Status.Todo;
        private const Status finalStatus = Status.Verified;

        private string assignee;

        public Task(string title, string assignee, DateTime dueDate)
            : base(title, dueDate)
        {
            this.Assignee = assignee;
            this.Status = initialStatus;

            this.AddEvent($"Created Task: '{this.Title}', [{this.Status}|{dueDate:d}]");
        }

        public string Assignee 
        { 
            get
            {
                return this.assignee;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Asignee cannot be null or empty.");
                }

                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Asignee must be between 5 and 30 characters long.");
                }

                if (!string.IsNullOrEmpty(this.assignee))
                {
                    this.AddEvent($"Asignee changed from '{this.assignee}' to '{value}'");
                }

                this.assignee = value;
            }
        }

        public override Status Status { get; protected set; }

        public override void AdvanceStatus()
        {
            if ((int)this.Status + 1 <= (int)finalStatus)
            {
                this.AddEvent($"Task changed from {this.Status} to {this.Status + 1}");

                this.Status++;
            }
            else
            {
                this.AddEvent($"Task status already {finalStatus}");
            }
        }

        public override void RevertStatus()
        {
            if ((int)this.Status - 1 >= (int)initialStatus)
            {
                this.AddEvent($"Task changed from {this.Status} to {this.Status - 1}");

                this.Status--;
            }
            else
            {
                this.AddEvent($"Task status already {initialStatus}");
            }
        }
    }
}
