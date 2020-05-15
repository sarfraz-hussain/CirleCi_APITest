using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serialization.Json;
using Report.Extent;

namespace APItestRestSharp
{
    public class APIRequest
    {
        #region Properties

        public readonly string url = "https://circleci.com/api/v1.1/";
        public string URL { get { return url; } }

        // public readonly string token = "8fd8007335391b00429c8133ee9841774bf844be";
        public readonly string token = "e9e5712b04bcbe0a009ae802f47bd141a64345a5";
        public string Token { get { return token; } }

        #endregion

        #region Methods

        public RestSharp.RestRequest BuildGETRequest(String Role)
        {
            var request = new RestRequest("{Role}", Method.GET);
            request.AddUrlSegment("Role", Role);
            request.AddParameter("circle-token", Token);
            return request;
        }
        public RestSharp.RestRequest BuildGETRequest(String Role, String invalidToken)
        {
            var request = new RestRequest("{Role}", Method.GET);
            request.AddUrlSegment("Role", Role);
            request.AddParameter("circle-token", invalidToken);
            return request;
        }


        public RestSharp.RestRequest BuildPOSTRequest()
        {

            var request = new RestRequest(Method.POST);
            request.AddParameter("Role", "project", ParameterType.UrlSegment);
            request.AddParameter("vcs-type", "github", ParameterType.UrlSegment);
            request.AddParameter("username", "sarfrazhus", ParameterType.UrlSegment); //sarfraz-hussain
            request.AddParameter("project", "cypress", ParameterType.UrlSegment);
            request.AddParameter("build", "follow", ParameterType.UrlSegment);
            request.AddQueryParameter("circle-token", Token);
            request.RequestFormat = DataFormat.Json;
            return request;
        }
        public RestSharp.RestRequest BuildPOSTRequest(string invalidUserName)
        {

            var request = new RestRequest(Method.POST);
            request.AddParameter("Role", "project", ParameterType.UrlSegment);
            request.AddParameter("vcs-type", "github", ParameterType.UrlSegment);
            request.AddParameter("username", invalidUserName, ParameterType.UrlSegment);
            request.AddParameter("project", "cypress", ParameterType.UrlSegment);
            request.AddParameter("build", "follow", ParameterType.UrlSegment);
            request.AddQueryParameter("circle-token", Token);
            request.RequestFormat = DataFormat.Json;
            return request;
        }


        public RestSharp.RestRequest BuildDELETERequest()
        {

            var request = new RestRequest(Method.DELETE);
            request.AddParameter("Role", "project", ParameterType.UrlSegment);
            request.AddParameter("vcs-type", "github", ParameterType.UrlSegment);
            request.AddParameter("username", "sarfrazhus", ParameterType.UrlSegment); //sarfraz-hussain
            request.AddParameter("project", "Selenium-CSharp", ParameterType.UrlSegment);
            request.AddParameter("build", "build-cache", ParameterType.UrlSegment);
            request.AddParameter("circle-token",Token);

            return request;
        }
        public RestSharp.RestRequest BuildDELETERequest(string invalidToken)
        {

            var request = new RestRequest(Method.DELETE);
            request.AddParameter("Role", "project", ParameterType.UrlSegment);
            request.AddParameter("vcs-type", "github", ParameterType.UrlSegment);
            request.AddParameter("username", "sarfrazhus", ParameterType.UrlSegment); //sarfraz-hussain
            request.AddParameter("project", "Selenium-CSharp", ParameterType.UrlSegment);
            request.AddParameter("build", "build-cache", ParameterType.UrlSegment);
            request.AddParameter("circle-token", invalidToken);

            return request;
        }


        public string jsonDeserialize(IRestResponse response, string key)
        {
            try
            {
                var deserial = new JsonDeserializer();
                var outPut = deserial.Deserialize<Dictionary<string, string>>(response);
                return ( outPut[key]);
            }
            catch (Exception e)
            {
                return (e.Message);
            }

        }

        #endregion
    }
}
