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

namespace WebIndex.WebFragment.Content.Seed
{
    /// <summary>
    /// Represents the initial link fragment which is a control panel fragment.
    /// </summary>
    [Section<SectionContentPrimary>]
    [Scope<WWW.Setting.Seed>]
    public sealed class SeedFragment : FragmentControlPanel
    {
        private ISitemapManager _sitemapManager;

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
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">The sitemap manager.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SeedFragment(ISitemapManager sitemapManager, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            _sitemapManager = sitemapManager;
            Table.RestUri = sitemapManager.GetUri<Api.V1.Seed>(fragmentContext.ApplicationContext);
        }

        /// <summary>
        /// Converts the fragment to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var restUri = _sitemapManager.GetUri<Api.V1.Seed>(FragmentContext.ApplicationContext);
            Table.OptionSettings.Icon = "fas fa-cog";

            Table.OptionItems.Clear();
            Table.OptionItems.Add(new ControlApiTableOptionItem(I18N.Translate(renderContext.Request?.Culture, "webexpress.webapp:delete.label"))
            {
                Icon = "fas fa-trash",
                Color = TypeColorText.Danger.ToClass(),
                OnClick = $"new webexpress.webui.modalFormCtrl({{ uri: '{restUri.ToString()}/' + item.id, size: 'small' }});"
            });

            return Table.Render(renderContext, visualTree);
        }
    }
}
