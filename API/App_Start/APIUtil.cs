using System.Linq;
using System.Net.Http.Headers;
using System.Configuration;
using CarelikeAPI.Helper;
using System.Collections.Generic;
using System;

namespace CarelikeAPI.App_Start
{
    /// <summary>
    /// API Util
    /// </summary>
    public class APIUtil
    {
        /// <summary>
        /// Strings the connection.
        /// </summary>
        /// <returns></returns>
        public static string strConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Determines whether [is valid request] [the specified headers].
        /// </summary>
        /// <param name="headers">The headers.</param>
        /// <returns>
        ///   <c>true</c> if [is valid request] [the specified headers]; otherwise, <c>false</c>.
        /// </returns>
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

        #region KeyClass
        /// <summary>
        /// Model key message
        /// </summary>
        public class KeyMessage
        {
            /// <summary>
            /// Model key
            /// </summary>
            public string Key { get; set; }
            /// <summary>
            /// Message
            /// </summary>
            public string Message { get; set; }
        }
        #endregion

        #region KeyErrorMessage
        /// <summary>
        /// Get model state errors
        /// </summary>
        /// <param name="Ex"></param>
        /// <returns></returns>
        public static List<KeyMessage> GetModelstateErrors(System.Web.Http.ModelBinding.ModelStateDictionary Ex)
        {
            List<KeyMessage> ErrorList = new List<KeyMessage>();
            foreach (var Key in Ex.Keys)
            {
                string newKey = Key;
                if (Ex[Key] != null)
                {
                    foreach (var error in Ex[Key].Errors)
                    {
                        try
                        {
                            if (newKey.Contains("."))
                            {
                                newKey = newKey.Split('.').Last();
                            }
                            else
                            {
                                newKey = "VALIDATION_ERROR";
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        ErrorList.Add(new KeyMessage()
                        {
                            Key = newKey,
                            Message = error.ErrorMessage + ((error.Exception != null) ? error.Exception.Message : string.Empty)
                        });
                    }
                }
            }
            return ErrorList;
        }
        #endregion
    }
}