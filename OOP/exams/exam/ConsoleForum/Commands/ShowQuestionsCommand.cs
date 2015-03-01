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

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            StringBuilder questionsResult = new StringBuilder();

            if (questions.Count == 0)
            {
                questionsResult.Append(Messages.NoQuestions).AppendLine();
            }
            else
            {
                this.Forum.CurrentQuestion = null;
                IEnumerable<IQuestion> orderedQuestions = questions.OrderBy(q => q.Id);

                foreach (IQuestion question in orderedQuestions)
                {
                    questionsResult.Append(Printer.PrintQuestionWithAnswers(question));
                }
            }

            this.Forum.Output.Append(questionsResult.ToString());
        }
    }
}
