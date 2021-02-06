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
using static CarelikeAPI.App_Start.APIUtil;
using CarelikeAPI.Helper;

namespace CarelikeAPI.Controllers
{
    
    public class CarelikeAPIController : BaseController
    {
        CarelikeBLL BLL = new CarelikeBLL(CustomCacheManagement.Connection.Carelike);
        CommonHelper objCommonHelper = new CommonHelper();

        /// <summary>
        /// Standards the API.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/standard")]
        [ResponseType(typeof(List<APIProvider>))]
        public HttpResponseMessage StandardAPI(StandardAPIRequestModel model)
        {
            try
            {
                if (IsValidRequest(Request.Headers))
                {
                    if (model != null && ModelState.IsValid)
                    {
                         
                        var RecordList = BLL.StandardAPI(model);
                        if (RecordList.Count > 0)
                        {
                            return ProvideResponse(RecordList);
                        }
                        else
                        {
                            return ProvideResponse<string>(null, HttpStatusCode.NotFound, true, Constants.NotFound);
                        }
                    }
                    else
                    {
                        return ProvideResponse<List<KeyMessage>>(GetModelstateErrors(ModelState), HttpStatusCode.BadRequest, false, Constants.BadRequest);
                    }
                }
                else
                {
                    return ProvideResponse<string>(null, HttpStatusCode.OK, false, Constants.InvalidAPIKey);
                }

            }
            catch (Exception ex)
            {
                return ProvideResponse<string>(objCommonHelper.HandleError(ex), HttpStatusCode.InternalServerError, false, Constants.InternalServerError);
            }


        }

        ///// <summary>
        ///// Standards the XML API.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <param name="pagesize">The pagesize.</param>
        ///// <param name="pageno">The pageno.</param>
        ///// <param name="since">The since.</param>
        ///// <param name="providerId">The provider identifier.</param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("api/carelike/xml")]
        //[ResponseType(typeof(List<APIResult>))]
        //public HttpResponseMessage StandardXMLAPI(string id, int pagesize = 0, int pageno = 0, string since = "", string providerId = "")
        //{
        //    return ProvideResponse<string>(null, HttpStatusCode.OK, false, string.Empty);

        //}

        /// <summary>
        /// Dynamics the json API.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="pagesize">The pagesize.</param>
        /// <param name="pageno">The pageno.</param>
        /// <param name="since">The since.</param>
        /// <param name="providerId">The provider identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/carelike/json")]
        [ResponseType(typeof(List<DynamicAPIModel>))]
        public HttpResponseMessage DynamicJsonAPI(string type,string id, int pagesize = 0, int pageno = 0, string since = "", string providerId = "")
        {
            return ProvideResponse<string>(null, HttpStatusCode.OK, false, string.Empty);

        }

        /// <summary>
        /// Dynamics the XML API.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="pagesize">The pagesize.</param>
        /// <param name="pageno">The pageno.</param>
        /// <param name="since">The since.</param>
        /// <param name="providerId">The provider identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/carelike/xml")]
        [ResponseType(typeof(List<DynamicAPIModel>))]
        public HttpResponseMessage DynamicXMLAPI(string type, string id, int pagesize = 0, int pageno = 0, string since = "", string providerId = "")
        {
            return ProvideResponse<string>(null, HttpStatusCode.OK, false, string.Empty);

        }


    }
}
