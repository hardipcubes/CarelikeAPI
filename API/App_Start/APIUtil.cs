using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Routing;
using CarelikeAPI.Models;
using BusinessObjects;
using System.Configuration;

namespace CarelikeAPI.App_Start
{
    public class APIUtil
    {
        public static string strConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        public static bool IsValidRequest(HttpHeaders headers)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["APIAccessToken"];
            string GetToken = FindKeyFromHeader(headers, Constants.AccessToken);
            if (GetToken == key)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Find specific key from HttpHeaders list
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string FindKeyFromHeader(HttpHeaders headers, string Key)
        {
            string strKeyValue = string.Empty;

            foreach (var item in headers.ToList())
            {
                if (item.Key.ToLower() == Key.ToLower())
                {
                    foreach (var value in item.Value)
                    {
                        strKeyValue += value + " ";
                    }
                    break;
                }
            }

            return strKeyValue.Trim();
        }
    }
}