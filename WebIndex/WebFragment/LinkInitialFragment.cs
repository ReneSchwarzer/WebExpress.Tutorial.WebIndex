using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;
using WebIndex.WebSettingPage;

namespace WebIndex.WebFragment
{
    /// <summary>
    /// Represents the initial link fragment which is a control panel fragment.
    /// </summary>
    [Section<SectionContentPrimary>]
    [Scope<IndexSettingPage>]
    public sealed class LinkInitialFragment : FragmentControlPanel
    {
        /// <summary>
        /// Returns the table.
        /// </summary>
        private ControlApiTable Table { get; } = new ControlApiTable()
        {
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Three)
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public LinkInitialFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Table.RestUri = fragmentContext.ApplicationContext.ContextPath.Append("api/1/indices");
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
