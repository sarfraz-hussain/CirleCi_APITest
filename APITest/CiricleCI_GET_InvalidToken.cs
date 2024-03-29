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
        /// Send API request to get details about user with In Valid API KEY
        /// </Scenario>

        /// <Expected_Results>
        /// Vrify API Key is not accepted and JSON seponse is sent  with STATUS CODE = 401
        /// </Expected_Results>

        #endregion

        [Test, Description("GET request with Invalid API Key Authentication")]
        public void CiricleCI_GET_InvalidToken()
        {

            APIRequest API = new APIRequest();
            var client = new RestClient(API.URL);
            var request = API.BuildGETRequest("me", "invalidToken");

            var fullUrl = client.BuildUri(request);
            var response = client.Execute(request);

            extent.LogRequest(fullUrl, Method.GET.ToString());
            extent.LogResponse(response);

            string jsonResponse = API.jsonDeserialize(response, "message");

            Assert.That(jsonResponse, Is.EqualTo("You must log in first."));
            extent.SetStepStatusInfo("JSON Response");
            extent.SetStepStatusPass(jsonResponse);

            Assert.That((int)response.StatusCode, Is.EqualTo(401));

        }

 }

}
