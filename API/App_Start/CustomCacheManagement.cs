using BusinessObjects;
using System.Web;

namespace CarelikeAPI.App_Start
{
    public class CustomCacheManagement
    {
        public static ConnectionModel Connection
        {
            get { return HttpRuntime.Cache["Connection"] as ConnectionModel; }
            set { HttpRuntime.Cache["Connection"] = value; }
        }
    }
}