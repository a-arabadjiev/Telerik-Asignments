namespace Board_R.Models.Base
{
    using Board_R.Models.Enums;

    using System.Text;

    public abstract class BoardItem
    {
        private string title;
        private DateTime dueDate;
        private readonly List<EventLog> events;

        protected BoardItem(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;

            events = new List<EventLog>();
        }

        public string Title
        {
            get
            {
                return title;
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

                if (!string.IsNullOrEmpty(title))
                {
                    AddEvent($"Title changed from '{title}' to '{value}'");
                }

                title = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Due date cannot be in the past");
                }

                if (dueDate > DateTime.Now)
                {
                    AddEvent($"DueDate changed from '{dueDate:d}' to '{value:d}'");
                }

                dueDate = value;
            }
        }

        public abstract Status Status { get; protected set; }

        public abstract void RevertStatus();

        public abstract void AdvanceStatus();

        public string ViewInfo()
        {
            return $"'{title}', [{Status}|{dueDate:G}]";
        }

        public string ViewHistory()
        {
            StringBuilder sb = new StringBuilder();

            foreach (EventLog currentEvent in events)
            {
                sb.AppendLine(currentEvent.ViewInfo());
            }

            return sb.ToString();
        }

        protected void AddEvent(string description)
        {
            EventLog currentEvent = new EventLog(description);

            events.Add(currentEvent);
        }
    }
}
