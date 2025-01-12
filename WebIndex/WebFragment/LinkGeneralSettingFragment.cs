using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;
using WebIndex.WebSettingPage;

namespace InventoryExpress.WebFragment
{
    /// <summary>
    /// Represents a fragment control for a dropdown item link to the general settings page.
    /// </summary>
    [Section<SectionAppSettingsSecondary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    public sealed class LinkGeneralSettingFragment : FragmentControlDropdownItemLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkGeneralSettingFragment"/> class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public LinkGeneralSettingFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "webindex:setting.label";
            Uri = componentHub.SitemapManager.GetUri<GeneralSettingPage>(fragmentContext.ApplicationContext);
            Icon = new PropertyIcon(TypeIcon.Wrench);
        }

        /// <summary>
        /// Converts the fragment to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            Active = renderContext.Endpoint is GeneralSettingPage ? TypeActive.Active : TypeActive.None;

            return base.Render(renderContext, visualTree);
        }

    }
}
