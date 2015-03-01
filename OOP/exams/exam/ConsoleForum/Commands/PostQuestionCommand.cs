namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            int questionId = this.Forum.Questions.Count + 1;
            string questionTitle = this.Data[1];
            string questionBody = this.Data[2];
            IUser questionUser = this.Forum.CurrentUser;
            IList<IAnswer> questionAnswers = new List<IAnswer>();
            IQuestion question = new Question(questionId, questionBody, questionUser, questionTitle, questionAnswers);

            this.Forum.Questions.Add(question);

            StringBuilder postQuestionResult = new StringBuilder();
            postQuestionResult.AppendFormat(Messages.PostQuestionSuccess, questionId);
            this.Forum.Output.AppendLine(postQuestionResult.ToString());
        }
    }
}
