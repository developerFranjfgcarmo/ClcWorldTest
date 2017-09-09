using System.Collections.Generic;

namespace ClcWorld.WebApi.Handlers
{
    /// <summary>
    /// Response Package for all request.
    /// </summary>
    public class ResponsePackage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="validationErrors"></param>
        /// <param name="message"></param>
        public ResponsePackage(object result, List<string> validationErrors, string message)
        {
            ValidationErrors = validationErrors;
            Result = result;
            Message = message;
        }

        /// <summary>
        /// List of Errors
        /// </summary>
        public List<string> ValidationErrors { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        public object Result { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}