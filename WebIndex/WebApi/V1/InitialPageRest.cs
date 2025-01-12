using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebApi;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebIndex.Wql;
using WebIndex.Model;

namespace WebIndex.WebApi.V1
{
    /// <summary>
    /// Returns all initial pages.
    /// </summary>
    [Segment("initialpages", "")]
    [ContextPath("/api/")]
    [Method(CrudMethod.POST)]
    [Method(CrudMethod.GET)]
    public sealed class InitialPageRest : RestApiCrud<InitialPageItem>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InitialPageRest()
        {
        }

        /// <summary>
        /// Processing of the resource that was called via the get request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>An enumeration of which json serializer can be serialized.</returns>
        public override IEnumerable<RestApiCrudColumn> GetColumns(Request request)
        {
            return
            [
                new RestApiCrudColumn(I18N.Translate(request, "webindex:url.label"))
                {
                    Render = "return item.Url;",
                    Width = 20
                }
            ];
        }

        /// <summary>
        /// Processing of the resource that was called via the get request.
        /// </summary>
        /// <param name="wql">The filtering and sorting options.</param>
        /// <param name="request">The request.</param>
        /// <returns>An enumeration of which json serializer can be serialized.</returns>
        public override IEnumerable<InitialPageItem> GetData(IWqlStatement<InitialPageItem> wql, Request request)
        {
            return wql?.Apply() ?? Enumerable.Empty<InitialPageItem>();
        }
    }
}
