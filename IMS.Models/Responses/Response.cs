using System;

namespace IMS.Models.Responses
{
    /// <summary>
    /// Represents a response returned from API endpoints.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets the numeric code associated with the response.
        /// </summary>
        public int CodeNum { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code associated with the response.
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets a message describing the status or result of the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the response (e.g., the response payload).
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets an authentication token (JWT token) associated with the response.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class with basic information.
        /// </summary>
        /// <param name="codeNum">The numeric code associated with the response.</param>
        /// <param name="code">The HTTP status code associated with the response.</param>
        /// <param name="statusMessage">A message describing the status or result of the response.</param>
        public Response(int codeNum, string code, string statusMessage)
        {
            CodeNum = codeNum;
            StatusCode = code;
            Message = statusMessage;
            Data = string.Empty;
            Token = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class with data.
        /// </summary>
        /// <param name="codeNum">The numeric code associated with the response.</param>
        /// <param name="code">The HTTP status code associated with the response.</param>
        /// <param name="statusMessage">A message describing the status or result of the response.</param>
        /// <param name="data">The data associated with the response (e.g., the response payload).</param>
        public Response(int codeNum, string code, string statusMessage, object data)
        {
            CodeNum = codeNum;
            StatusCode = code;
            Message = statusMessage;
            Data = data;
            Token = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class with data and an authentication token.
        /// </summary>
        /// <param name="codeNum">The numeric code associated with the response.</param>
        /// <param name="code">The HTTP status code associated with the response.</param>
        /// <param name="statusMessage">A message describing the status or result of the response.</param>
        /// <param name="data">The data associated with the response (e.g., the response payload).</param>
        /// <param name="token">An authentication token (JWT token) associated with the response.</param>
        public Response(int codeNum, string code, string statusMessage, object data, string token)
        {
            CodeNum = codeNum;
            StatusCode = code;
            Message = statusMessage;
            Data = data;
            Token = token;
        }
    }
}
