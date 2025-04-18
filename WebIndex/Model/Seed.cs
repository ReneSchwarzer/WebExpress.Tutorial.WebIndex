using System;
using WebExpress.WebIndex;
using WebExpress.WebIndex.WebAttribute;

namespace WebIndex.Model
{
    /// <summary>
    /// The class contains information about a initial webpage.
    /// </summary>
    public class Seed : IIndexItem
    {
        /// <summary>
        /// The URL of the webpage.
        /// </summary>
        [IndexIgnore]
        public Guid Id { get; set; }

        /// <summary>
        /// Returns or sets the URL of the webpage.
        /// </summary>
        [IndexDefaultSearch]
        public string Url { get; set; }
    }
}
