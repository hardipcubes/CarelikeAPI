using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarelikeAPI.Helper
{
    public class CommonHelper
    {
        string isDisplayError = string.Empty;
        public CommonHelper()
        {
            this.isDisplayError = System.Configuration.ConfigurationManager.AppSettings["displayerror"];
        }
        public string HandleError(Exception ex)
        {
            return isDisplayError == "true" ? ex.Message : null;
        }
    }
}