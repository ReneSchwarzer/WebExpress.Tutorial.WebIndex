using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSettingPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSettingPage;
using WebExpress.WebUI.WebIcon;

namespace WebIndex.WWW.Setting
{
    [WebIcon<IconSeedling>]
    [Title("webindex:setting.seed.label")]
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
