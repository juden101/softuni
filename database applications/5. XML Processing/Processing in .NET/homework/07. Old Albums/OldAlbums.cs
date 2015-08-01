namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class OldAlbums
    {
        static void Main()
        {
            var doc = XDocument.Load("../../../music-albums.xml");
            var currYear = DateTime.Now.Year - 5;

            var linqCatalog = doc.XPathSelectElements("music/artist/album")
                .Where(c =>
                {
                    var year = c.Attribute("year");
                    return year != null && int.Parse(year.Value) <= currYear;
                })
                .Select(c => new
                {
                    Title = c.Attribute("title"),
                    Price = c.Attribute("price")
                })
                .ToList();

            foreach (var album in linqCatalog)
            {
                Console.WriteLine("{0} - {1}", album.Title.Value, album.Price.Value);
            }
        }
    }
}