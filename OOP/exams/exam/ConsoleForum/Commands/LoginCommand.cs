namespace ConsoleForum.Commands
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            ICollection<IUser> users = this.Forum.Users;

            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if(this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            IUser user = (User)users.First(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            this.Forum.CurrentUser = user;

            StringBuilder loginResult = new StringBuilder();
            loginResult.AppendFormat(Messages.LoginSuccess, username);
            this.Forum.Output.AppendLine(loginResult.ToString());
        }
    }
}
