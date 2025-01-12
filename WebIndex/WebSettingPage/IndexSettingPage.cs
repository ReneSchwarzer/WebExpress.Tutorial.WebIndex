using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSettingPage;

namespace WebIndex.WebSettingPage
{
    /// <summary>
    /// Represents the settings page for the index.
    /// </summary>
    [Title("webindex:index.label")]
    [Segment("index", "webindex:index.label")]
    [ContextPath("/setting")]
    [SettingGroup("webindex:setting.general.label")]
    [SettingContext("webexpress.webapp:setting.tab.general.label")]
    //[SettingSection<SettingSectionPreferences>)]
    //[SettingIcon(TypeIcon.Globe)]
    [Scope<IScopeAdmin>]
    public sealed class IndexSettingPage : ISettingPage<VisualTreeWebApp>, IScopeAdmin
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public IndexSettingPage()
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
