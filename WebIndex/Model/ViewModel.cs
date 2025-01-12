using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebExpress.WebApp.WebIndex;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebComponent;

namespace WebIndex.Model
{
    /// <summary>
    /// Provides methods for initializing and interacting with the index.
    /// </summary>
    internal static class ViewModel
    {
        private static IComponentHub _componentHub;

        /// <summary>
        /// Initialization.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="applicationContext">The application context.</param>
        public static void Initialization(IComponentHub componentHub, IApplicationContext applicationContext)
        {
            _componentHub = componentHub;

            // indexing the data
            _componentHub.GetComponentManager<IndexManager>()?.Create<InitialPageItem>(CultureInfo.CurrentCulture, WebExpress.WebIndex.IndexType.Storage);
            _componentHub.GetComponentManager<IndexManager>()?.Create<PageItem>(CultureInfo.CurrentCulture, WebExpress.WebIndex.IndexType.Storage);

            //_componentHub.GetComponentManager<IndexManager>()?.ReIndex<InitialPageItem>();

            if ((bool)!_componentHub.GetComponentManager<IndexManager>()?
                .Retrieve<InitialPageItem>("Url = 'https://www.gutenberg.org/'")?
                .Apply()
                .Any())
            {
                AddInitialPage(new InitialPageItem() { Id = Guid.NewGuid(), Url = "https://www.gutenberg.org/" });
                //AddInitialPage(new InitialPageItem() { Id = Guid.NewGuid(), Url = "https://wikipedia.de" });

                WebCrawler.Crawl();
            }
        }

        /// <summary>
        /// Adds an initial page to the index.
        /// </summary>
        /// <param name="page">The initial page to add to the index.</param>
        public static void AddInitialPage(InitialPageItem page)
        {
            _componentHub.GetComponentManager<IndexManager>()?.Insert(page);
        }

        /// <summary>
        /// Retrieves a collection from the index that match the specified search string.
        /// </summary>
        /// <param name="search">The search string to match against the index.</param>
        /// <returns>An enumerable that match the search string.</returns>
        public static IEnumerable<PageItem> Retrieve(string search)
        {
            return _componentHub.GetComponentManager<IndexManager>()?.Retrieve<PageItem>(search)?.Apply().Where(x => x != null);
        }
    }
}
