namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    class ExtractAllArtistsAlphabetically
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../music-albums.xml");

            var artistsSet = new SortedSet<string>();

            var music = doc.DocumentElement;
            var artists = music.ChildNodes;

            foreach (XmlElement artist in artists)
            {
                var currentArtist = artist.Attributes["name"].InnerText;
                artistsSet.Add(currentArtist);
            }

            string allArtists = string.Join("\n", artistsSet);
            Console.WriteLine(allArtists);
        }
    }
}