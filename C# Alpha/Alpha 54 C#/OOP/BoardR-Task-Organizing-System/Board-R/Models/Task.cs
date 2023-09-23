namespace Board_R.Models
{
    using Board_R.Models.Enums;

    public class Task : BoardItem
    {
        private const Status initialStatus = Status.Todo;

        private string assignee;

        public Task(string title, string assignee, DateTime dueDate)
            : base(title, dueDate, initialStatus)
        {
            this.Assignee = assignee;
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
    }
}
