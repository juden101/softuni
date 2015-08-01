namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    
    class ExtractAlbumNames
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../music-albums.xml");

            var albums = new List<string>();

            var music = doc.DocumentElement;
            var artists = music.ChildNodes;

            foreach (XmlElement artist in artists)
            {
                var currentArtistAlbums = artist.ChildNodes;

                foreach (XmlElement album in currentArtistAlbums)
                {
                    var currentAlbumTitle = album.Attributes["title"].InnerText;
                    albums.Add(currentAlbumTitle);
                }
            }

            string allAlbums = string.Join("\n", albums);
            Console.WriteLine(allAlbums);
        }
    }
}