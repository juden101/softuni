namespace VehicleParkSystem
{
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    public class Command : ICommand
    {
        public Command(string commandString)
        {
            this.Name = commandString.Substring(0, commandString.IndexOf(' '));
            this.Parameters = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(commandString.Substring(commandString.IndexOf(' ') + 1));
        }

        public string Name
        {
            get;
            set;
        }

        public IDictionary<string, string> Parameters
        {
            get;
            set;
        }
    }
}