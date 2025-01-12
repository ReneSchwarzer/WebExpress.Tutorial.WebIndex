using System.Linq;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebIndex.WebPage
{
    /// <summary>
    /// Represents the info page for the tutorial.
    /// </summary>
    [Title("webindex:infopage.label")]
    [Segment("info", "webindex:infopage.label")]
    [Scope<IScopeGeneral>]
    public sealed class InfoPage : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoPage"/> class.
        /// </summary>
        public InfoPage()
        {
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            var webexpress = WebEx.ComponentHub.PluginManager.Plugins.Where(x => x.PluginId.ToString() == "webexpress.webapp").FirstOrDefault();
            var webindex = WebEx.ComponentHub.PluginManager.Plugins.Where(x => x.Assembly == GetType().Assembly).FirstOrDefault();

            visualTree.Content.Primary.Add(new ControlImage()
            {
                Uri = renderContext.PageContext.ContextPath.Append("assets/img/webindex.svg"),
                Width = 200,
                Height = 200,
                HorizontalAlignment = TypeHorizontalAlignment.Right
            });

            var card = new ControlPanelCard()
            {
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
            };

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webindex:app.name"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webindex:app.description"),
                Format = TypeFormatText.Paragraph
            });

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webindex:app.about"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = string.Format
                (
                    I18N.Translate(renderContext.Request?.Culture, "webindex:app.version.label"),
                    I18N.Translate(renderContext.Request?.Culture, webindex?.PluginName),
                    webindex?.Version,
                    webexpress?.PluginName,
                    webexpress?.Version
                ),
                TextColor = new PropertyColorText(TypeColorText.Primary)
            });

            visualTree.Content.Primary.Add(card);
        }
    }
}
