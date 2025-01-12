using WebExpress.WebCore;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPlugin;

namespace WebIndex
{
    /// <summary>
    /// Represents a plugin for the WebIndex application.
    /// </summary>
    [Name("webindex:plugin.name")]
    [Description("webindex:plugin.description")]
    [Icon("/assets/img/webindex.svg")]
    [Application<Application>]
    public sealed class Plugin : IPlugin
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Plugin()
        {
        }

        /// <summary>
        /// Called when the plugin starts working. Run is called concurrently.
        /// </summary>
        public void Run()
        {
        }
    }
}