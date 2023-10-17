namespace Dealership.Models
{
    using Dealership.Exceptions;
    using Dealership.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Metadata;
    using System.Text;

    public class User : IUser
    {
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";

        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const string InvalidNameLengthError = "{0}name must be between 2 and 20 characters long!";

        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const string InvalidPasswordFormatError = "Username contains invalid symbols!";
        private const string InvalidPasswordLengthError = "Password must be between 5 and 30 characters long!";

        private const int MaxVehiclesToAdd = 5;

        private const string NotAVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";
        private const string CommentsHeader = "    --COMMENTS--";
        private const string NoCommentsHeader = "    --NO COMMENTS--";
        private const string CommentsSeperator = "    ----------";

        private string username;
        private string firstName;
        private string lastName;
        private string password;

        private readonly IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, Role role)
        {

            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;

            this.vehicles = new List<IVehicle>();
        }

        public Role Role { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, string.Format(InvalidNameLengthError, "User"));
                Validator.ValidateSymbols(value, UsernamePattern, InvalidUsernameFormatError);
                this.username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, string.Format(InvalidNameLengthError, "First"));
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, string.Format(InvalidNameLengthError, "Last"));
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, PasswordMinLength, PasswordMaxLength, InvalidPasswordLengthError);
                Validator.ValidateSymbols(value, PasswordPattern, InvalidPasswordFormatError);
                this.password = value;
            }
        }

        public IList<IVehicle> Vehicles => new List<IVehicle>(this.vehicles);

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.AddComment(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            this.ValidateUserCanAddVehicle();

            this.vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            StringBuilder sb = new();
            sb.AppendLine($"--USER {Username}--");
            if (vehicles.Count <= 0)
            {
                sb.AppendLine(NoVehiclesHeader);
            }
            else
            {
                int count = 1;
                foreach (var vehicle in Vehicles)
                {
                    sb.AppendLine($"{count++}.{vehicle.ToString()}");
                    if (vehicle.Comments.Count <= 0)
                    { sb.AppendLine($"    --NO COMMENTS--"); }
                    else
                    {
                        sb.AppendLine("    --COMMENTS--");
                        for (int i = 0; i < vehicle.Comments.Count; i++)
                        {
                            sb.AppendLine("    ----------");
                            sb.AppendLine($"    {vehicle.Comments[i].Content}");
                            sb.AppendLine($"      User: {vehicle.Comments[i].Author}");
                            sb.AppendLine("    ----------");
                        }
                        { sb.AppendLine($"    --COMMENTS--"); }
                    }
                }
                return sb.ToString();
            }
            return sb.ToString().Trim();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            this.ValidateUserCanRemoveComment(commentToRemove);

            vehicleToRemoveComment.RemoveComment(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.vehicles.Remove(vehicle);
        }

        private void ValidateUserCanRemoveComment(IComment commentToRemove)
        {
            if (commentToRemove.Author != this.Username)
            {
                throw new AuthorizationException(YouAreNotTheAuthor);
            }
        }

        private void ValidateUserCanAddVehicle()
        {
            if (this.Role == Role.Admin)
            {
                throw new AuthorizationException(AdminCannotAddVehicles);
            }
            if (this.Role != Role.VIP && this.vehicles.Count == MaxVehiclesToAdd)
            {
                throw new AuthorizationException(string.Format(NotAVipUserVehiclesAdd, MaxVehiclesToAdd));
            }
        }

        public override string ToString()
        {
            string userToString = ($"Username: {this.Username}, FullName: {this.FirstName} {this.LastName}, Role: {this.Role}");

            return userToString;
        }
    }
}
