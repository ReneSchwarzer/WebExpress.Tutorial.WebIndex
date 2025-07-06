﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebExpress.WebApp.WebIndex;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebNotification;

namespace WebExpress.Tutorial.WebIndex.Model
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
            _indexManager.Create<Document>(CultureInfo.CurrentCulture, WebExpress.WebIndex.IndexType.Storage);


            if (!_indexManager.All<Seed>().Any())
            {
#if DEBUG
                AddSeed(new Seed() { Id = Guid.NewGuid(), Url = "https://www.gutenberg.org/" });
                AddSeed(new Seed() { Id = Guid.NewGuid(), Url = "https://www.wikipedia.org/" });
#endif
            }
        }

        /// <summary>
        /// Clears all documents from the catalog associated with the specified request.
        /// </summary>
        /// <param name="context"> The render context containing the request information.</param>
        public static void ClearCatalog(IRenderContext context)
        {
            _componentHub.GetComponentManager<IndexManager>()?.Clear<Document>();

            _componentHub.GetComponentManager<NotificationManager>()?.AddNotification
            (
                applicationContext: context?.PageContext?.ApplicationContext,
                message: I18N.Translate(context, "webexpress.tutorial.webindex:setting.catalog.cleared"),
                durability: 2000,
                icon: context?.PageContext?.Route.Concat("/assets/img/crawler.svg")?.ToString()
            );
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
        /// Updates the specified seed in the system by inserting it into the index manager.
        /// </summary>
        /// <param name="seed">The seed to be updated. Cannot be null.</param>
        public static void UpdateSeed(Seed seed)
        {
            _componentHub.GetComponentManager<IndexManager>()?.Update(seed);
        }

        /// <summary>
        /// Retrieves a collection from the index that match the specified search string.
        /// </summary>
        /// <param name="search">The search string to match against the index.</param>
        /// <returns>An enumerable that match the search string.</returns>
        public static IEnumerable<Document> Retrieve(string search)
        {
            return _componentHub.GetComponentManager<IndexManager>()?.Retrieve<Document>(search)?.Apply().Where(x => x != null);
        }
    }
}
