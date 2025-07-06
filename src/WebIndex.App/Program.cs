using System.Reflection;

namespace HalloWorld.App
{
    internal class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        /// <param name="args">Call arguments.</param>
        static void Main(string[] args)
        {
            var app = new WebExpress.WebCore.WebEx()
            {
                Name = Assembly.GetExecutingAssembly().GetName().Name
            };

            app.Execution(args);
        }
    }
}