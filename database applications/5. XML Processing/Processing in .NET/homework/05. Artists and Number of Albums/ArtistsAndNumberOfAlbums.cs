namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    class ArtistsAndNumberOfAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../music-albums.xml");
            string xPathQuery = "/music/artist/album";
            var artistsAndAlbums = new Dictionary<string, int>();

            XmlNodeList albumsList = doc.SelectNodes(xPathQuery);
            foreach (XmlNode album in albumsList)
            {
                string currentArtist = album.ParentNode.Attributes["name"].InnerText;

                if (!artistsAndAlbums.ContainsKey(currentArtist))
                {
                    artistsAndAlbums[currentArtist] = 1;
                    continue;
                }

                artistsAndAlbums[currentArtist]++;
            }

            foreach (var artistWithAlbumns in artistsAndAlbums)
            {
                Console.WriteLine("Artist: {0} has {1} albumns", artistWithAlbumns.Key, artistWithAlbumns.Value);
            }
        }
    }
}