namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Contracts;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int answerId = int.Parse(this.Data[1]);

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            else if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }
            else if (!this.Forum.Answers.Any(a => a.Id == answerId))
            {
                throw new CommandException(Messages.NoAnswer);
            }
            else if (this.Forum.CurrentUser != this.Forum.CurrentQuestion.Author && this.Forum.CurrentUser != this.Forum.Users[0])
            {
                throw new CommandException(Messages.NoPermission);
            }

            IAnswer oldAnswer = this.Forum.Answers.First(a => a.Id == answerId);
            IAnswer newBestAnswer = new BestAnswer(oldAnswer.Id, oldAnswer.Body, oldAnswer.Author);

            this.Forum.Answers.Add(newBestAnswer);
            this.Forum.CurrentQuestion.Answers.Add(newBestAnswer);

            this.Forum.Answers.Remove(oldAnswer);
            this.Forum.CurrentQuestion.Answers.Remove(oldAnswer);

            StringBuilder bestAnswerResult = new StringBuilder();
            bestAnswerResult.AppendFormat(Messages.BestAnswerSuccess, answerId);
            this.Forum.Output.AppendLine(bestAnswerResult.ToString());
        }
    }
}