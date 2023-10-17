namespace Dealership.Commands
{
    using Dealership.Core.Contracts;
    using Dealership.Exceptions;
    using Dealership.Models;

    using System.Collections.Generic;
    using System.Text;

    public class ShowUsersCommand : BaseCommand
    {
        public ShowUsersCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }
        public ShowUsersCommand(IRepository repository)
            : base(repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            if (this.Repository.LoggedUser.Role != Role.Admin)
            {
                throw new AuthorizationException("You are not an admin!");
            }

            return this.ShowUsers();
        }

        private string ShowUsers()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--USERS--");

            int count = 1;
            foreach (var user in this.Repository.Users)
            {
                sb.AppendLine($"{count++}. {user}");
            }

            return sb.ToString();
        }
    }
}
