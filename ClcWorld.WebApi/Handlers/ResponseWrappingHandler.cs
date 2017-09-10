using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Newtonsoft.Json;

namespace ClcWorld.WebApi.Handlers
{
    /// <summary>
    ///     http://www.exceptionnotfound.net/custom-validation-in-asp-net-web-api-with-fluentvalidation/
    /// </summary>
    public class ResponseWrappingHandler : DelegatingHandler
    {
        public ResponseWrappingHandler()
        {
        }

        public ResponseWrappingHandler(HttpConfiguration httpConfiguration)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // Step 1: Wait for the Response
            var response = await base.SendAsync(request, cancellationToken);           
            return BuildApiResponse(request, response);
        }

        private HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            object content;
            var modelStateErrors = new List<string>();
            var message = string.Empty;

            // Step 2: Get the Response Content
            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                var error = content as HttpError;
                if (error != null)
                {
                    // Step 3: If content is an error, return nothing for the Result.
                    content = null; //We have errors, so don't return any content
                    // Step 4: Insert the ModelState errors              
                    if (error.ModelState != null)
                    {
                        // Read as string
                        var httpErrorObject = response.Content.ReadAsStringAsync().Result;

                        // Convert to anonymous object
                        var anonymousErrorObject = new { message = "", ModelState = new Dictionary<string, string[]>() };

                        // Deserialize anonymous object
                        var deserializedErrorObject = JsonConvert.DeserializeAnonymousType(httpErrorObject,
                            anonymousErrorObject);

                        // Get error messages from ModelState object
                        var modelStateValues =
                            deserializedErrorObject.ModelState.Select(kvp => string.Join(". ", kvp.Value));

                        var stateValues = modelStateValues as IList<string> ?? modelStateValues.ToList();
                        modelStateErrors.AddRange(stateValues.Select((t, i) => (string) stateValues.ElementAt(i)));
                    }
                }
            }
           
            response.TryGetContentValue(out content);

            // Step 5: Create a new response
            var newResponse = request.CreateResponse(response.StatusCode, new ResponsePackage(content, modelStateErrors, message));

            // Step 6: AddOrUpdate Back the Response Headers
            foreach (var header in response.Headers) //AddOrUpdate back the response headers
            {
                newResponse.Headers.Add(header.Key, header.Value);
            }

            return newResponse;
        }
    }
}