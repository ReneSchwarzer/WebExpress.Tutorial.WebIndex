using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSettingPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSettingPage;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebIndex.WWW.Setting
{
    /// <summary>
    /// Represents a settings page for configuring general settings in a web application.
    /// </summary>
    [WebIcon<IconSeedling>]
    [Title("webexpress.tutorial.webindex:setting.seed.label")]
    [SettingCategory<SettingCategoryGeneral>()]
    [SettingGroup<SettingGroupGeneral>()]
    [SettingSection(SettingSection.Primary)]
    [Scope<IScopeAdmin>]
    public sealed class Seed : ISettingPage<VisualTreeWebAppSetting>, IScopeAdmin
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Seed()
        {
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebAppSetting visualTree)
        {
        }
    }
}
