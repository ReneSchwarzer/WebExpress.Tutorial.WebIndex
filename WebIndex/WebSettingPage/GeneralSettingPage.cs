using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSettingPage;
using WebExpress.WebCore.WebSettingPage.Model;

namespace WebIndex.WebSettingPage
{
    [Title("webindex:setting.label")]
    [Segment("general", "webindex:setting.label")]
    [ContextPath("/setting")]
    [SettingGroup("webindex:setting.general.label")]
    [SettingContext("webexpress.webapp:setting.tab.general.label")]
    [SettingSection(SettingSection.Primary)]
    //[SettingIcon(TypeIcon.Wrench)]
    [Scope<IScopeAdmin>]
    public sealed class GeneralSettingPage : ISettingPage<VisualTreeWebApp>, IScopeAdmin
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public GeneralSettingPage()
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
