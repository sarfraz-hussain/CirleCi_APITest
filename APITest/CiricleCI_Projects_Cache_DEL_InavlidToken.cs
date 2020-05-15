using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APItestRestSharp
{
    #region Test Description

    /// <Scenario>
    /// Send API request to DELETE project cache with In Valid API KEY
    /// </Scenario>

    /// <Expected_Results>
    /// Vrify DELETE operation is un successful with JSON response and  STATUS CODE = 403
    /// </Expected_Results>

    #endregion
    public partial class Tests: TestBase
    {
        [Test, Description("DELTE request to remove projects Cache details with Invalid API Key")]
        public void CiricleCI_Projects_Cache_DEL_InavlidToken()
        {
            APIRequest API = new APIRequest();

            var client = new RestClient(API.URL + "{Role}/{vcs-type}/{username}/{project}/{build}");
            var request = API.BuildDELETERequest("invalidToken");

            var fullUrl = client.BuildUri(request);
            var response = client.Execute(request);

            extent.LogRequest(fullUrl, Method.DELETE.ToString());
            extent.LogResponse(response);

            string jsonResponse = API.jsonDeserialize(response, "message");

            Assert.That(jsonResponse, Is.EqualTo("Permission denied"));
            extent.SetStepStatusInfo("JSON Response");
            extent.SetStepStatusPass(jsonResponse);

            Assert.That((int)response.StatusCode, Is.EqualTo(403));

        }

    }

}
