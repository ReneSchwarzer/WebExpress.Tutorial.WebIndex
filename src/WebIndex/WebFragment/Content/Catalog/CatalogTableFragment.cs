using WebExpress.Tutorial.WebIndex.WebControl;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebIndex.WebFragment.Content.Catalog
{
    /// <summary>
    /// Represents the fragment control panel for the index page.
    /// </summary>
    /// <remarks>
    /// This fragment is used to display a table with initial pages and provides options to manage them.
    /// </remarks>
    [Section<SectionContentPrimary>]
    [Scope<WWW.Setting.Catalog>]
    public sealed class CatalogTableFragment : FragmentControlPanel
    {
        /// <summary>
        /// Returns the table.
        /// </summary>
        private ControlRestTable Table { get; } = new ControlRestTable()
        {
            Margin = new PropertySpacingMargin
            (
                PropertySpacing.Space.None,
                PropertySpacing.Space.None,
                PropertySpacing.Space.None,
                PropertySpacing.Space.Three
            )
        };

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name="sitemapManager">The sitemap manager.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public CatalogTableFragment(ISitemapManager sitemapManager, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            var form = new CatalogForm("indexForm");
            var uri = sitemapManager.GetUri<WWW.Setting.Catalog>(fragmentContext.ApplicationContext);

            Table.RestUri = sitemapManager.GetUri<WWW.Api._1.Catalog>(fragmentContext.ApplicationContext);

            form.ItemUri.Initialize(x => x.Value = uri?.ToString());

            Table.Add(form);
        }

        /// <summary>
        /// Converts the fragment to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            return Table.Render(renderContext, visualTree);
        }
    }
}
