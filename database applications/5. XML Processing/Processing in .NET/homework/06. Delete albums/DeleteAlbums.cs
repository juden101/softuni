namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class DeleteAlbums
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("../../../music-albums.xml");

            doc.Descendants("album")
                .Where(
                    a => a.Attribute("price") == null ||
                    double.Parse(a.Attribute("price").Value) > 20)
                .Remove();
            doc.Save("../../../cheap-music-albums.xml");
        }
    }
}