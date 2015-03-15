using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Web.Controllers
{
    internal class EchoNestHelper
    {
        private readonly string baseUrl;
        private readonly string echoNestKey;

        public EchoNestHelper()
        {
            baseUrl = ConfigurationManager.AppSettings["EchoNestBaseUrl"];
            echoNestKey = ConfigurationManager.AppSettings["EchoNestApiKey"];
        }

        protected string CreateUrl(string query)
        {
            return baseUrl + query + "&api_key=" + echoNestKey;
        }

        public string MakeEchoNestRequest(string query)
        {
            string response = null;
            string enQuery = CreateUrl(query);
            WebRequest webRequest;
            webRequest = WebRequest.Create(enQuery);

            Stream objStream;
            objStream = webRequest.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);
            response = objReader.ReadToEnd();
            return response;
        }
    }
}