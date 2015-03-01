namespace ConsoleForum.Entities
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Entities.Posts;
    using Entities.Users;

    public static class Printer
    {
        public static string PrintQuestionWithAnswers(IQuestion question)
        {
            StringBuilder questionsResult = new StringBuilder();

            questionsResult.AppendFormat("[ Question ID: {0} ]", question.Id).AppendLine();
            questionsResult.AppendFormat("Posted by: {0}", question.Author.Username).AppendLine();
            questionsResult.AppendFormat("Question Title: {0}", question.Title).AppendLine();
            questionsResult.AppendFormat("Question Body: {0}", question.Body).AppendLine();
            questionsResult.AppendFormat("{0}", new String('=', 20)).AppendLine();

            if (question.Answers.Count == 0)
            {
                questionsResult.AppendFormat("No answers").AppendLine();
            }
            else
            {
                questionsResult.AppendFormat("Answers:").AppendLine();

                IAnswer bestAnswer = question.Answers.FirstOrDefault(a => a is BestAnswer);
                IEnumerable<IAnswer> orderedAnswers = question.Answers.Where(a => !(a is BestAnswer)).OrderBy(a => a.Id);

                if (bestAnswer != null)
                {
                    questionsResult.AppendFormat("{0}", new String('*', 20)).AppendLine();
                    questionsResult.AppendFormat("[ Answer ID: {0} ]", bestAnswer.Id).AppendLine();
                    questionsResult.AppendFormat("Posted by: {0}", bestAnswer.Author.Username).AppendLine();
                    questionsResult.AppendFormat("Answer Body: {0}", bestAnswer.Body).AppendLine();
                    questionsResult.AppendFormat("{0}", new String('-', 20)).AppendLine();
                    questionsResult.AppendFormat("{0}", new String('*', 20)).AppendLine();
                }

                foreach (IAnswer answer in orderedAnswers)
                {
                    questionsResult.AppendFormat("[ Answer ID: {0} ]", answer.Id).AppendLine();
                    questionsResult.AppendFormat("Posted by: {0}", answer.Author.Username).AppendLine();
                    questionsResult.AppendFormat("Answer Body: {0}", answer.Body).AppendLine();
                    questionsResult.AppendFormat("{0}", new String('-', 20)).AppendLine();
                }
            }

            return questionsResult.ToString();
        }

        public static string PrintHeader(IUser currentUser, ICollection<IQuestion> questions, ICollection<IAnswer> answers)
        {
            StringBuilder header = new StringBuilder();

            header.AppendLine(new string('~', 20));
            header.AppendLine(currentUser == null ?
                "Hey stranger, care to login/register?" :
                string.Format("Welcome, {0}!", currentUser.Username));

            IDictionary<IUser, int> usersAnswers = new Dictionary<IUser, int>();
            foreach (IAnswer answer in answers)
            {
                if (!usersAnswers.ContainsKey(answer.Author))
                {
                    usersAnswers.Add(answer.Author, 0);
                }

                usersAnswers[answer.Author]++;
            }

            int hotQuestions = questions.Count(q => q.Answers.Any(a => a is BestAnswer));
            int activeUsers = usersAnswers.Count(ua => ua.Value > 2);

            header.AppendFormat("Hot questions: {0}, Active users: {1}", hotQuestions, activeUsers).AppendLine();
            header.AppendLine(new string('~', 20));

            return header.ToString();
        }
    }
}
