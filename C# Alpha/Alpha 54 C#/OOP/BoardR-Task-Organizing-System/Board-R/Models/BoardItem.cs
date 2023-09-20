using Board_R.Models.Enums;
using System.Text;

namespace Board_R.Models
{
    public  class BoardItem
    {
        private const Status initialStatus = Status.Open;
        private const Status finalStatus = Status.Verified;

        private string title;
        private DateTime dueDate;
        private Status status;
        private readonly List<EventLog> events;

        public BoardItem(string title, DateTime dueDate)
        {
            this.Title = title;
            this.DueDate = dueDate;
            this.status = Status.Open;
            this.events = new List<EventLog>();

            this.AddEvent($"Item created: '{title}', [{status}|{dueDate:d}]");
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title cannot be null or empty.");
                }

                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Title must be between 5 and 30 characters long.");
                }

                if (!string.IsNullOrEmpty(this.title))
                {
                    this.AddEvent($"Title changed from '{this.title}' to '{value}'");
                }

                this.title = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Due date cannot be in the past");
                }

                if (this.dueDate > DateTime.Now)
                {
                    this.AddEvent($"DueDate changed from '{this.dueDate:d}' to '{value:d}'");
                }

                this.dueDate = value;
            }
        }

        public Status Status 
        { 
            get
            {
                return this.status;
            }
        }

        public void RevertStatus()
        {
            if (this.status != initialStatus)
            {
                this.AddEvent($"Status changed from {this.status} to {this.status - 1}");

                this.status--;
            }
            else
            {
                this.AddEvent($"Can't revert, already at {initialStatus}");
            }
        }

        public void AdvanceStatus()
        {
            if (this.status != finalStatus)
            {
                this.AddEvent($"Status changed from {this.status} to {this.status + 1}");

                this.status++;
            }
            else
            {
                this.AddEvent($"Can't advance, already at {finalStatus}");
            }
        }

        public string ViewInfo()
        {
            return $"'{this.title}', [{this.status}|{this.dueDate:G}]";
        }

        public string ViewHistory()
        {
            StringBuilder sb = new StringBuilder();

            foreach (EventLog currentEvent in this.events)
            {
                sb.AppendLine(currentEvent.ViewInfo());
            }

            return sb.ToString();
        }

        private void AddEvent(string description)
        {
            EventLog currentEvent = new EventLog(description);
            
            this.events.Add(currentEvent);
        }
    }
}
