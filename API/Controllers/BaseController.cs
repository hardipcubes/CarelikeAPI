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
        /// <summary>
        /// provides dbpath connection string.
        /// </summary>
        /// <param name="CompanyId">The company identifier.</param>
        /// <param name="User">The username.</param>
        /// <param name="Password">The password.</param>
        /// <returns></returns>
        //protected string DBPathConnectionString(int CompanyId, string User, string Password)
        //{
        //    string devPasswordConnectionString = System.Configuration.ConfigurationManager.
        //                ConnectionStrings["DevPassword"].ConnectionString;
        //    UserLoginDAL objUserLoginDAL = new UserLoginDAL(devPasswordConnectionString);
        //    string databaseId = objUserLoginDAL.ProcessGetDatabaseID(CompanyId);
        //    string DBPath = objUserLoginDAL.ProcessGetString(Convert.ToInt32(databaseId), User, Password);
        //    return DBPath;
        //}

    }
}
