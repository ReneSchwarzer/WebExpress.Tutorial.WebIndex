using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebIndex.WebFragment.Content.Seed
{
    /// <summary>
    /// Represents the initial link fragment which is a control panel fragment.
    /// </summary>
    [Section<SectionContentPrimary>]
    [Scope<WWW.Setting.Seed>]
    public sealed class SeedTableFragment : FragmentControlPanel
    {
        private ISitemapManager _sitemapManager;

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
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">The sitemap manager.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SeedTableFragment(ISitemapManager sitemapManager, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            var form = new SeedForm("seedForm");
            form.Uri = sitemapManager.GetUri<WWW.Setting.Seed>(fragmentContext.ApplicationContext);

            Table.RestUri = sitemapManager.GetUri<WWW.Api._1.Seed>(fragmentContext.ApplicationContext);

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
