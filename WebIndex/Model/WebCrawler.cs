using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using WebExpress.WebApp.WebIndex;
using WebExpress.WebCore;

namespace WebIndex.Model
{
    /// <summary>
    /// WebCrawler class that crawls web pages and stores the data.
    /// </summary>
    internal static class WebCrawler
    {
        public static ConcurrentDictionary<Guid, string> Urls = new();

        /// <summary>
        /// Starts the web crawling process.
        /// </summary>
        public static void Crawl()
        {
            WebEx.ComponentHub.GetComponentManager<IndexManager>()?.Clear<PageItem>();

            foreach (var initial in WebEx.ComponentHub.GetComponentManager<IndexManager>().All<InitialPageItem>())
            {
                Urls.TryAdd(initial.Id, initial.Url);
            }

            //var notification = WebEx.ComponentHub.GetComponentManager<NotificationManager>()?.AddNotification
            //(
            //    message: "<p>start indexing</p>",
            //    durability: -1
            //);

            var task = new Task(() =>
            {
                while (!Urls.IsEmpty && Urls.TryRemove(Urls.Keys.FirstOrDefault(), out string url))
                {
                    Crawl(url);

                    var count = WebEx.ComponentHub.GetComponentManager<IndexManager>().Count<PageItem>();

                    //notification.Message = $"<p>add url '{url}' ({count}/1000)</p>";

                    if (count > 100)
                    {
                        break;
                    }
                }
            });

            task.Start();
        }

        /// <summary>
        /// Crawls a specific URL and stores the data.
        /// </summary>
        /// <param name="url">The URL to crawl.</param>
        public static void Crawl(string url)
        {
            if (url == null || url.StartsWith("mailto") || url.StartsWith("tel") || WebEx.ComponentHub.GetComponentManager<IndexManager>().Retrieve<PageItem>($"url='{url}'").Apply().Any())
            {
                return;
            }

            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var title = doc.DocumentNode.SelectSingleNode("//head/title")?.InnerText;
                var content = doc.DocumentNode?.InnerText;

                if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(content))
                {
                    var webPageData = new PageItem
                    {
                        Id = Guid.NewGuid(),
                        Url = url,
                        Title = title,
                        Content = content,
                        Create = DateTime.Now,
                    };

                    WebEx.ComponentHub.GetComponentManager<IndexManager>().Insert(webPageData);

                    var links = doc.DocumentNode.SelectNodes("//a[@href]");
                    foreach (var link in links ?? Enumerable.Empty<HtmlNode>())
                    {
                        var hrefValue = link.GetAttributeValue("href", string.Empty);
                        if (!string.IsNullOrEmpty(hrefValue) && Uri.IsWellFormedUriString(hrefValue, UriKind.Absolute))
                        {
                            Urls.TryAdd(Guid.NewGuid(), hrefValue);
                        }
                    }
                }

            }
            catch
            {
            }

            //ComponentManager.GetComponent<LogManager>()?.DefaultLog.Info($"add url '{url}' to index");
        }
    }
}
