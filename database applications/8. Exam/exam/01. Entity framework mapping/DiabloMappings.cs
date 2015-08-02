namespace DiabloMappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DiabloMappings
    {
        public static void Main()
        {
            var diabloContext = new DiabloEntities();

            var charactersNames = diabloContext.Characters
                .Select(c => new
                {
                    name = c.Name
                });

            foreach (var character in charactersNames)
            {
                Console.WriteLine(character.name);
            }
        }
    }
}