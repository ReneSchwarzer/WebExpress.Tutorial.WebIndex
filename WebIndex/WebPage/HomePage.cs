using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;

namespace WebIndex.WebPage
{
    [Title("webindex:homepage.label")]
    [Segment(null, "webindex:homepage.label")]
    [ContextPath(null)]
    [Scope<IScopeGeneral>]
    public sealed class HomePage : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public HomePage()
        {
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
        }
    }
}
