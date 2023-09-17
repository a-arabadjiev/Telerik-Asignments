using Board_R.Models.Enums;

namespace Board_R.Models
{
    public  class BoardItem
    {
        public string title;
        public DateTime dueDate;
        private Status status;

        public Status initialStatus = Status.Open;
        public Status finalStatus = Status.Verified;

        public BoardItem(string title, DateTime dueDate)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Title cannot be null or empty.");
            }

            if (title.Length < 5 || title.Length > 30)
            {
                throw new ArgumentException("Title must be between 5 and 30 characters long.");
            }

            if (dueDate < DateTime.Now)
            {
                throw new ArgumentException("Due date cannot be in the past");
            }

            this.title = title;
            this.dueDate = dueDate;

            this.status = Status.Open;
        }

        public Status Status 
        { 
            get
            {
                return this.status;
            }
            private set
            {
                this.status = value;
            }
        }

        public void RevertStatus()
        {
            if (this.status != this.initialStatus)
            {
                this.status--;
            }
        }

        public void AdvanceStatus()
        {
            if (this.status != this.finalStatus) 
            {
                this.status++;
            }
        }

        public string ViewInfo()
        {
            return $"'{this.title}', [{this.status}|{this.dueDate.ToString("dd-MM-yyyy")}]";
        }
    }
}
