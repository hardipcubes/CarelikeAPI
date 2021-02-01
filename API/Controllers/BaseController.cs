using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessObjects.ViewModel;
using DataAccess;
using System;
using BusinessObjects;
using CarelikeAPI.App_Start;

namespace CarelikeAPI.Controllers
{
    /// <summary>
    /// Base Controller of all controllers
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseController : ApiController
    {
        /// <summary>
        /// Provides the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="Message">The message.</param>
        /// <returns></returns>
        protected HttpResponseMessage ProvideResponse<T>(T result, HttpStatusCode statusCode = HttpStatusCode.OK, bool isSuccess = true, string Message = "Success")
        {
            return Request.CreateResponse(statusCode, new APIResponseBase<T>()
            {
                Result = result,
                StatusCode = statusCode,
                IsSuccess = isSuccess,
                Message = Message
            });
        }
         

    }
}
