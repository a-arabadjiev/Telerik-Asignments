using Board_R.Models.Enums;
using System.Net.Http.Headers;

namespace Board_R.Models
{
    public class Issue : BoardItem
    {
        private const Status initialStatus = Status.Open;
        private const string noDescription = ". No description";
        private const string descriptionSeperator = ". ";

        private readonly string description;

        public Issue(string title, string description, DateTime dueDate) 
            : base(title, dueDate, initialStatus, 
                  string.IsNullOrEmpty(description)? noDescription: descriptionSeperator + description) // Passes either "No description" if null or description value
        {
            this.description = description ?? "No description";
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
