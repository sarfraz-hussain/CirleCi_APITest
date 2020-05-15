using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APItestRestSharp
{
    public partial class Tests: TestBase
    {
        #region Test Description

            /// <Scenario>
            /// Send API request to get details about user with Valid API KEY
            /// </Scenario>

            /// <Expected_Results>
            /// Vrify API Key is accepted and user details is sent back with STATUS CODE = 200
            /// </Expected_Results>

        #endregion

        [Test, Description("GET request with API Key Authentication")]
        public void CiricleCI_GET()
        {

            APIRequest API = new APIRequest();
            var client = new RestClient(API.URL);
            var request = API.BuildGETRequest("me");

            var fullUrl = client.BuildUri(request);
            var response = client.Execute(request);

            extent.LogRequest(fullUrl, Method.GET.ToString());
            extent.LogResponse(response);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

        }


    }

}
