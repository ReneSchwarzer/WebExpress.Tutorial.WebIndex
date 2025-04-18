using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebApi;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebIndex.Wql;

namespace WebIndex.Api.V1
{
    /// <summary>
    /// Represents a REST API endpoint for CRUD operations on Seed entities.
    /// </summary>
    [Method(CrudMethod.POST)]
    [Method(CrudMethod.GET)]
    public sealed class Seed : RestApiCrud<Model.Seed>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Seed()
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
        public override IEnumerable<Model.Seed> GetData(IWqlStatement<Model.Seed> wql, Request request)
        {
            return wql?.Apply() ?? Enumerable.Empty<Model.Seed>();
        }
    }
}
