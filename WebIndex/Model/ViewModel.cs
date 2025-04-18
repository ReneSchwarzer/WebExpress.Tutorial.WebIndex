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
        private static IndexManager _indexManager;

        /// <summary>
        /// Initialization.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="applicationContext">The application context.</param>
        public static void Initialization(IComponentHub componentHub, IApplicationContext applicationContext)
        {
            _componentHub = componentHub;
            _indexManager = _componentHub.GetComponentManager<IndexManager>();

            // indexing the data
            _indexManager.Create<Seed>(CultureInfo.CurrentCulture, WebExpress.WebIndex.IndexType.Storage);
            _indexManager.Create<Index>(CultureInfo.CurrentCulture, WebExpress.WebIndex.IndexType.Storage);


            if (!_indexManager.All<Seed>().Any())
            {
#if DEBUG
                AddSeed(new Seed() { Id = Guid.NewGuid(), Url = "https://www.gutenberg.org/" });
                AddSeed(new Seed() { Id = Guid.NewGuid(), Url = "https://www.wikipedia.org/" });
#endif
            }
        }

        /// <summary>
        /// Adds an initial page to the index.
        /// </summary>
        /// <param name="seed">The initial seed uri to add to the index.</param>
        public static void AddSeed(Seed seed)
        {
            _componentHub.GetComponentManager<IndexManager>()?.Insert(seed);
        }

        /// <summary>
        /// Retrieves a collection from the index that match the specified search string.
        /// </summary>
        /// <param name="search">The search string to match against the index.</param>
        /// <returns>An enumerable that match the search string.</returns>
        public static IEnumerable<Index> Retrieve(string search)
        {
            return _componentHub.GetComponentManager<IndexManager>()?.Retrieve<Index>(search)?.Apply().Where(x => x != null);
        }
    }
}
