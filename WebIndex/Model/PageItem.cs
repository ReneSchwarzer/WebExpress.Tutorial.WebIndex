using System;
using WebExpress.WebIndex;
using WebExpress.WebIndex.WebAttribute;

namespace WebIndex.Model
{
    /// <summary>
    /// The class contains information about a webpage.
    /// </summary>
    public class PageItem : IIndexItem
    {
        /// <summary>
        /// The URL of the webpage.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Returns or sets the URL of the webpage.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Returns or sets the title of the webpage.
        /// </summary>
        [IndexDefaultSearch]
        public string Title { get; set; }

        ///// <summary>
        ///// Returns or sets the content of the webpage.
        ///// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Returns or sets the date when the webpage was added to the index.
        /// </summary>
        [IndexIgnore]
        public DateTime Create { get; set; }
    }
}
