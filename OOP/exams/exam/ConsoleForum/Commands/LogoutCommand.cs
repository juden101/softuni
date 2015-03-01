namespace ConsoleForum.Commands
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using ConsoleForum.Contracts;

    public class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            ICollection<IUser> users = this.Forum.Users;

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            this.Forum.CurrentUser = null;
            this.Forum.CurrentQuestion = null;

            StringBuilder logoutResult = new StringBuilder();
            logoutResult.Append(Messages.LogoutSuccess);
            this.Forum.Output.AppendLine(logoutResult.ToString());
        }
    }
}
