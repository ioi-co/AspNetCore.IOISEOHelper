# AspNetCore.IOISEOHelper
I have created a seperate post for this Package. Please <a href="https://codingwithesty.com/search-engine-optimization-library-for-dot-net-code-developers">    click<a /> this link for details.

Helps to create routing  robots.txt  and sitemap.xml for asp.net core project.

Routing for  <a href="https://codingwithesty.com/search-engine-optimization-library-for-dot-net-code-developers#routingrobotstxt"> robots.txt</a>
  ```csharp
  app.UseRobotsTxt(env.ContentRootPath);
  ```

Routing for <a href="https://codingwithesty.com/search-engine-optimization-library-for-dot-net-code-developers#routesitemapxml">sitemap.xml</a>
  ```csharp
  app.UseXMLSitemap(env.ContentRootPath);
  ```

Creating SEO friendly URL
  ```csharp
  string queryString = "Asp.Net MVC Tutorial Part-1";
  var seoQueryString = queryString.ToSEOQueryString();
  var url = $"http://www.ioi-co.com/{seoQueryString}";
  ```

How to create sitemap.xml <a href="https://codingwithesty.com/search-engine-optimization-library-for-dot-net-code-developers#createsitemap">click for details</a>

```csharp
var list = new List<SitemapNode>
();
list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codingwithesty.com/serilog-mongodb-in-asp-net-core", Frequency = SitemapFrequency.Daily });
list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codingwithesty.com/logging-in-asp-net-core", Frequency = SitemapFrequency.Yearly });

new SitemapDocument().CreateSitemapXML(list, _env.ContentRootPath);

```

Loading Existing sitemap.xml
```csharp
List items = new SitemapDocument().LoadFromFile(_env.ContentRootPath);
```


How to Create news.rss <a href="https://validator.w3.org/feed/docs/rss2.html">click for details</a>

```csharp
// using AspNetCore.IOISEOHelper

var feed = new Feed()
{
Title = "Shawn ioi-co's Blog",
Description = "My Favorite Rants and Raves",
Link = new Uri("http://ioi-co.com/feed"),
Copyright = "(c) 2016"
};

var item1 = new Item()
{
Title = "Foo Bar",
Body = "<p>Foo bar</p>",
Link = new Uri("http://ioi-co.com/item#1"),
Permalink = "http://ioi-co.com/item#1",
PublishDate = DateTime.UtcNow,
Author = new Author() { Name = "Shawn ioi-co", Email = "shawn@foo.com" }
};

item1.Categories.Add("aspnet");
item1.Categories.Add("ioi-co");

item1.Comments = new Uri("http://ioi-co.com/item1#comments");

feed.Items.Add(item1);

var item2 = new Item()
{
Title = "Quux",
Body = "<p>Quux</p>",
Link = new Uri("http://quux.com/item#1"),
Permalink = "http://quux.com/item#1",
PublishDate = DateTime.UtcNow,
Author = new Author() { Name = "Shawn ioi-co", Email = "shawn@foo.com" }
};

item1.Categories.Add("aspnet");
item1.Categories.Add("quux");

feed.Items.Add(item2);

//var rss = feed.Serialize();

new RssDocument().CreateSitemapXML(feed, _env.ContentRootPath, "news.rss");

```
