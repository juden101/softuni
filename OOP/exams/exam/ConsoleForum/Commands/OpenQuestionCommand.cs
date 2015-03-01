namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleForum.Entities;
    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {

            int questionId = int.Parse(this.Data[1]);

            IQuestion question = this.Forum.Questions.FirstOrDefault(q => q.Id == questionId);
            if (question == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = question;

            string questionResult = Printer.PrintQuestionWithAnswers(question);
            this.Forum.Output.Append(questionResult);
        }
    }
}
