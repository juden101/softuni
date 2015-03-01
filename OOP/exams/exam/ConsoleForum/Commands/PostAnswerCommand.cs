namespace ConsoleForum.Commands
{
    using System;
    using System.Text;

    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            else if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            int answerId = this.Forum.Answers.Count + 1;
            string answerBody = this.Data[1];
            IUser answerUser = this.Forum.CurrentUser;
            IAnswer newAnswer = new Answer(answerId, answerBody, answerUser);

            this.Forum.Answers.Add(newAnswer);
            this.Forum.CurrentQuestion.Answers.Add(newAnswer);

            StringBuilder postAnswerResult = new StringBuilder();
            postAnswerResult.AppendFormat(Messages.PostAnswerSuccess, answerId);
            this.Forum.Output.AppendLine(postAnswerResult.ToString());
        }
    }
}
