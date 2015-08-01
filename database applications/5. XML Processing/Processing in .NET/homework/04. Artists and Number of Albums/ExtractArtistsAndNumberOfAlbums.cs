namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    class ExtractArtistsAndNumberOfAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../music-albums.xml");

            var artistsAndAlbums = new Dictionary<string, int>();

            var music = doc.DocumentElement;
            var artists = music.ChildNodes;

            foreach (XmlElement artist in artists)
            {
                var currentArtist = artist.Attributes["name"].InnerText;
                var currentArtistAlbums = artist.ChildNodes;

                if (!artistsAndAlbums.ContainsKey(currentArtist))
                {
                    artistsAndAlbums[currentArtist] = 0;
                }

                foreach (XmlElement album in currentArtistAlbums)
                {
                    artistsAndAlbums[currentArtist]++;
                }
            }

            foreach (var artistWithAlbumns in artistsAndAlbums)
            {
                Console.WriteLine("Artist: {0} has {1} albumns", artistWithAlbumns.Key, artistWithAlbumns.Value);
            }
        }
    }
}