namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;
    using System.Text;

    public class RegisterCommand : AbstractCommand
    {
        public RegisterCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            ICollection<IUser> users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);
            string email = this.Data[3];

            if (users.Any(u => u.Username == username || u.Email == email))
            {
                throw new CommandException(Messages.UserAlreadyRegistered);
            }

            User user;

            if (this.Data.Count > 4)
            {
                string role = this.Data[4];

                switch (role.ToLower())
                {
                    case "administrator":
                        if (users.Any())
                        {
                            throw new CommandException(Messages.RegAdminNotAllowed);
                        }

                        user = new Administrator(users.Count + 1, username, password, email);
                        break;
                    default:
                        user = new User(users.Count + 1, username, password, email);
                        break;
                }
            }
            else
            {
                user = new User(users.Count + 1, username, password, email);
            }

            users.Add(user);

            StringBuilder registerCommand = new StringBuilder();
            registerCommand.AppendFormat(Messages.RegisterSuccess, username, users.Last().Id);
            this.Forum.Output.AppendLine(registerCommand.ToString());
        }
    }
}
