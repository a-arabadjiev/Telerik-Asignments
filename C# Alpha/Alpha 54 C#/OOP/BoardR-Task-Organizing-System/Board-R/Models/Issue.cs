using Board_R.Models.Enums;
using System.Net.Http.Headers;

namespace Board_R.Models
{
    public class Issue : BoardItem
    {
        private const Status initialStatus = Status.Open;

        private readonly string description;

        public Issue(string title, string description, DateTime dueDate) 
            : base(title, dueDate, initialStatus, 
                  string.IsNullOrEmpty(description)? ". No description": ". " + description) // Passes either "No description" if null or description value
        {
            if (string.IsNullOrEmpty(description))
            {
                this.description = "No description";
            }
            else 
            {
                this.description = description;
            }
        }

        public string Description
        {
            get 
            { 
                return this.description; 
            }
        }
    }
}
