using System.Linq;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;
using WebIndex.Model;
using WebIndex.WebCondition;
using WebIndex.WebPage;

namespace WebIndex.WebFragment
{
    /// <summary>
    /// Represents a fragment control panel for displaying search results on the home page.
    /// </summary>
    [Section<SectionContentSecondary>]
    [Scope<HomePage>]
    [Condition<SerachCondition>]
    public sealed class HomeResultFragment : FragmentControlPanelFlexbox
    {
        /// <summary>
        /// Returns the list control for displaying search results.
        /// </summary>
        public ControlVirtualList List { get; } = new ControlVirtualList()
        {
            Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
            Width = TypeWidth.OneHundred
        };

        /// <summary>
        /// Returns the pagination control for navigating through search results.
        /// </summary>
        public ControlPagination Pagination { get; } = new ControlPagination()
        {

        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public HomeResultFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Layout = TypeLayoutFlexbox.Default;
            Align = TypeAlignFlexbox.Center;
            Justify = TypeJustifiedFlexbox.Center;
            Direction = TypeDirection.Vertical;

            Add(List);
            Add(Pagination);

            List.RetrieveVirtualItem += OnRetrieveVirtualItem;
        }

        /// <summary>
        /// Handles the event when a virtual item needs to be retrieved.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data containing information about the virtual item to retrieve.</param>
        private void OnRetrieveVirtualItem(object sender, RetrieveVirtualListItemEventArgs e)
        {
            var param = e.RenderContext.Request.GetParameter("search");

            if (param == null)
            {
                return;
            }

            var res = ViewModel.Retrieve($"Content ~ '{param?.Value}'");

            e.Items = res.Select
            (
                x => new ControlListItem
                (
                    null,
                    new ControlText()
                    {
                        Text = x?.Title
                    },
                    new ControlLink()
                    {
                        Text = x?.Url,
                        Uri = x?.Url
                    }
                )
            );
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