namespace Board_R.Models
{
    public class EventLog
    {
        private readonly string description;
        private readonly DateTime time;

        public EventLog(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description cannot be null or empty.");
            }

            this.description = description;
            this.time = DateTime.Now;
        }

        public string Description
        {
            get 
            { 
                return this.description; 
            }
        }

        public DateTime Time
        {
            get 
            {
                return this.time;
            }
        }

        public string ViewInfo()
        {
            string info = $"[{this.Time:G}] - {this.Description}";

            return info;
        }
    }
}
