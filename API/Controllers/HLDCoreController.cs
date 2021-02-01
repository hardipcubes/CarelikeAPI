using BusinessObjects.ViewModel;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLogic;
using System.Collections.Generic;
using BusinessObjects;
using CarelikeAPI.App_Start;
using CarelikeAPI.Models;

namespace CarelikeAPI.Controllers
{
    /// <summary>
    ///  Carelike API Controller Class
    /// </summary>
    /// <seealso cref="CarelikeAPI.Controllers.BaseController" />
    [RoutePrefix("api")]
    public class HLDCoreController : BaseController
    {
        HLDCoreBLL BLL = new HLDCoreBLL(CustomCacheManagement.Connection.HLDCore);

        /// <summary>
        /// Gets the application list.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Application/Get")]
        [ResponseType(typeof(APIResponseBase<List<ApplicationResultModel>>))]
        public HttpResponseMessage GetApplicationList(ApplicationParamModel model)
        {
            try
            {
                if (APIUtil.IsValidRequest(Request.Headers))
                {
                    var RecordList = BLL.GetApplicationList(model);
                    if (RecordList.Count > 0)
                    {
                        return ProvideResponse(RecordList);
                    }
                    else
                    {
                        return ProvideResponse<string>(null, HttpStatusCode.NotFound, true, "No record found.");
                    }
                }
                else
                {
                    return ProvideResponse<string>(null, HttpStatusCode.OK, false, "Api key is not valid.");
                }

            }
            catch (Exception ex)
            {
                return ProvideResponse<string>(null, HttpStatusCode.InternalServerError, false, "Unable to process request.");
            }
        }

        [HttpGet]
        [Route("Application/GetProvider")]
        [ResponseType(typeof(APIResponseBase<List<APIResult>>))]
        public HttpResponseMessage GetAPIModel(string id, int pagesize = 0, int pageno = 0, string since = "", string providerId = "")
        {
            try
            {
                if (APIUtil.IsValidRequest(Request.Headers))
                {
                    var RecordList = BLL.GetApplicationList(null);
                    if (RecordList.Count > 0)
                    {
                        return ProvideResponse(RecordList);
                    }
                    else
                    {
                        return ProvideResponse<string>(null, HttpStatusCode.NotFound, true, "No record found.");
                    }
                }
                else
                {
                    return ProvideResponse<string>(null, HttpStatusCode.OK, false, "Api key is not valid.");
                }

            }
            catch (Exception ex)
            {
                return ProvideResponse<string>(null, HttpStatusCode.InternalServerError, false, "Unable to process request.");
            }
        }
    }
}
