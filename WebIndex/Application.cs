using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebIndex.Model;

namespace WebIndex
{
    /// <summary>
    /// Represents the main application class for the WebIndex application.
    /// </summary>
    [Name("webindex:app.name")]
    [Description("webindex:app.description")]
    [Icon("/assets/img/webindex.svg")]
    [ContextPath("/webindex")]
    public sealed class Application : IApplication
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="applicationContext">The context that applies to the execution of the application</param>
        public Application(IComponentHub componentHub, IApplicationContext applicationContext)
        {
            ViewModel.Initialization(componentHub, applicationContext);
        }

        /// <summary>
        /// Called when the application starts working. The call is concurrent. 
        /// </summary>
        public void Run()
        {
        }
    }
}