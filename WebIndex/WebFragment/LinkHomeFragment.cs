using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;
using WebIndex.WebPage;

namespace WebIndex.WebFragment
{
    /// <summary>
    /// Represents a navigation item link for the home page.
    /// </summary>
    /// <remarks>
    /// This fragment is used to create a navigation link to the Info page with an icon and label.
    /// </remarks>
    [Section<SectionAppNavigationPrimary>]
    [Scope<IScopeGeneral>]
    [Scope<IScopeAdmin>]
    [Cache]
    public sealed class LinkHomeFragment : FragmentControlNavigationItemLink
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public LinkHomeFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "webindex:homepage.label";
            Uri = componentHub.SitemapManager.GetUri<HomePage>(fragmentContext.ApplicationContext);
            Icon = new PropertyIcon(TypeIcon.Home);
        }

        /// <summary>
        /// Converts the fragment to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            Active = renderContext.Endpoint is HomePage ? TypeActive.Active : TypeActive.None;

            return base.Render(renderContext, visualTree);
        }
    }
}