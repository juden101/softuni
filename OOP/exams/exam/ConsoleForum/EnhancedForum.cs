namespace ConsoleForum
{
    using System;

    using Entities;
    using Contracts;
    using Commands;

    class EnhancedForum : Forum
    {   
        protected override void ExecuteCommandLoop()
        {
            this.Output.Clear();

            string header = Printer.PrintHeader(this.CurrentUser, this.Questions, this.Answers);
            this.Output.Append(header);

            Console.Write(this.Output);

            base.ExecuteCommandLoop();
        }
    }
}
