using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;
using WebIndex.WWW.Setting;

namespace WebIndex.WebFragment.Headline
{
    /// <summary>
    /// Represents a fragment control for a link to the index settings page.
    /// </summary>
    /// <remarks>
    /// This fragment is used within the secondary toolbar to provide a link to the index settings page.
    /// </remarks>
    [Section<SectionHeadlineMoreSecondary>]
    [Scope<Index>]
    public sealed class ClearIndexFragment : FragmentControlDropdownItemLink
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public ClearIndexFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "webindex:setting.index.clear.label";
            Uri = componentHub.SitemapManager.GetUri<Index>(fragmentContext.ApplicationContext);
            TextColor = new PropertyColorText(TypeColorText.Danger);
            Icon = new IconTrash();
            Modal = new PropertyModal(TypeModal.Modal, new ControlModalFormConfirmDelete());
        }

        /// <summary>
        /// Converts the fragment to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            return base.Render(renderContext, visualTree);
        }
    }
}
