using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;
using WebIndex.Api.V1;
using WebIndex.WWW.Setting;

namespace WebIndex.WebFragment.Content.Index
{
    /// <summary>
    /// Represents the fragment control panel for the index page.
    /// </summary>
    /// <remarks>
    /// This fragment is used to display a table with initial pages and provides options to manage them.
    /// </remarks>
    [Section<SectionContentPrimary>]
    [Scope<WWW.Setting.Index>]
    public sealed class IndexFragment : FragmentControlPanel
    {
        /// <summary>
        /// Returns the table.
        /// </summary>
        private ControlApiTable Table { get; } = new ControlApiTable()
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
        public IndexFragment(ISitemapManager sitemapManager, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Table.RestUri = sitemapManager.GetUri<Api.V1.Index>(fragmentContext.ApplicationContext);
        }

        /// <summary>
        /// Converts the fragment to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            Table.OptionSettings.Icon = "fas fa-cog";

            Table.OptionItems.Clear();
            Table.OptionItems.Add(new ControlApiTableOptionItem(I18N.Translate(renderContext.Request?.Culture, "webexpress.webapp:delete.label"))
            {
                Icon = "fas fa-trash",
                Color = TypeColorText.Danger.ToClass(),
                OnClick = $"new webexpress.webui.modalFormularCtrl({{ uri: '{renderContext.PageContext.ApplicationContext.ContextPath.Concat("setting/seed/del/")}/' + item.id, size: 'small' }});"
            });

            return Table.Render(renderContext, visualTree);
        }
    }
}
