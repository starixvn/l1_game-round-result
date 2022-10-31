using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Io;

namespace GameRoundResult.IntegrationTests.Helpers
{
    public static class HtmlHelpers
    {
        public static async Task<(IHtmlDocument, IBrowsingContext)> GetDocumentAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var context = BrowsingContext.New();
            var document = await context.OpenAsync(ResponseFactory, CancellationToken.None);
            return ((IHtmlDocument)document, context);

            void ResponseFactory(VirtualResponse htmlResponse)
            {
                htmlResponse
                    .Address(response.RequestMessage.RequestUri)
                    .Status(response.StatusCode);

                MapHeaders(htmlResponse, response.Headers);
                MapHeaders(htmlResponse, response.Content.Headers);
                htmlResponse.Content(content);
            }
        }

        private static void MapHeaders(VirtualResponse htmlResponse, HttpHeaders headers)
        {
            foreach (var header in headers)
            {
                foreach (var value in header.Value)
                {
                    htmlResponse.Header(header.Key, value);
                }
            }
        }
    }
}