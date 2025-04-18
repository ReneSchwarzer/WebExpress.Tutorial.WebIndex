using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;
using WebIndex.Model;

namespace WebIndex.WebFragment.Headline
{
    /// <summary>
    /// Represents a fragment control form for initiating a web crawling operation.
    /// </summary>
    [Section<SectionHeadlineSecondary>]
    [Scope<WWW.Setting.Seed>]
    public sealed class CrawlFragment : FragmentControlForm
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public CrawlFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Margin = new PropertySpacingMargin(PropertySpacing.Space.Two);

            AddPrimaryButton(new ControlFormItemButtonSubmit()
            {
                Text = "webindex:run.label",
                BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success),
                Icon = new IconPlayCircle()
            });
        }

        /// <summary>
        /// Processes the form submission and initiates the web crawling operation.
        /// </summary>
        /// <param name="renderContext">The context in which the form is rendered.</param>
        protected override void OnProcess(IRenderControlFormContext renderContext)
        {
            WebCrawler.Crawl(renderContext.Request);
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
