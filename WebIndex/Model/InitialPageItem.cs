using System;
using WebExpress.WebIndex;

namespace WebIndex.Model
{
    /// <summary>
    /// The class contains information about a initial webpage.
    /// </summary>
    public class InitialPageItem : IIndexItem
    {
        /// <summary>
        /// The URL of the webpage.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Returns or sets the URL of the webpage.
        /// </summary>
        public string Url { get; set; }
    }
}
