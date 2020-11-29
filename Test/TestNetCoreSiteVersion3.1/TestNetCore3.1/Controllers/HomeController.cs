using AspNetCore.IOISEOHelper.RSSFeed;
using AspNetCore.IOISEOHelper.Sitemap;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestNetCore3._1.Models;

namespace TestNetCore3._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string TestSiteMap()
        {
            var list = new List<SitemapNode>();
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://www.example.com/asp-dot-net-turotial-part1", Frequency = SitemapFrequency.Daily });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://www.example.com/asp-dot-net-turotial-part2", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.7, Url = "https://www.example.com/asp-dot-net-turotial-part3", Frequency = SitemapFrequency.Monthly });

            new SitemapDocument()
                .CreateSitemapXML(list, _env.ContentRootPath);

            return "sitemap.xml file should be create in root directory";
        }

        public string TestRSS()
        {
            var feed = new Feed()
            {
                Title = "Nima Ataee's Blog",
                Description = "My Favorite Rants and Raves",
                Link = new Uri("http://wildermuth.com/feed"),
                Copyright = "(c) 2016"
            };

            var item1 = new Item()
            {
                Title = "Foo Bar",
                Body = "<p>Foo bar</p>",
                Link = new Uri("http://IOI-Co.com/item#1"),
                Permalink = "http://IOI-Co.com/item#1",
                PublishDate = DateTime.UtcNow,
                Author = new Author() { Name = "Nima Ataee", Email = "shawn@foo.com" }
            };

            item1.Categories.Add("aspnet");
            item1.Categories.Add("IOI-Co");

            item1.Comments = new Uri("http://IOI-Co.com/item1#comments");

            feed.Items.Add(item1);

            var item2 = new Item()
            {
                Title = "IOI-Co",
                Body = "<p>IOI-Co</p>",
                Link = new Uri("http://IOI-Co.com/item#1"),
                Permalink = "http://IOI-Co.com/item#1",
                PublishDate = DateTime.UtcNow,
                Author = new Author() { Name = "Nima Ataee", Email = "nimasoftco@gmail.com" }
            };

            item1.Categories.Add("aspnet");
            item1.Categories.Add("IOI-Co");

            feed.Items.Add(item2);

            new RssDocument().CreateSitemapXML(feed, _env.ContentRootPath);
            return "rss file should be create in root directory";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
