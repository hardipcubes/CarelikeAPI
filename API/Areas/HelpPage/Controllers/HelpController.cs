using System;
using System.Web.Http;
using System.Web.Mvc;
using CarelikeAPI.Areas.HelpPage.Models;

namespace CarelikeAPI.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public partial class HelpController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }
        /// <summary>
        /// 
        /// </summary>
        public HttpConfiguration Configuration { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiId"></param>
        /// <returns></returns>
        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View("Error");
        }
    }
}