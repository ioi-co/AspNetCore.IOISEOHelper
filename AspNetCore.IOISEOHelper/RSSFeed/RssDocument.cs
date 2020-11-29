using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace AspNetCore.IOISEOHelper.RSSFeed
{
    public class RssDocument
    {
        public void CreateSitemapXML(Feed feed, string directoryPath, string FileName = "news.rss")
        {
            var rss = feed.Serialize();
            //XDocument document = new XDocument(rss);
            //document.Save(Path.Combine(directoryPath, FileName));
            string docPath = Path.Combine(directoryPath);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FileName)))
            {
                outputFile.Write(rss);
            }
        }
    }
}
