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
        /// Send API request to DELETE project cache with Valid API KEY
        /// </Scenario>

        /// <Expected_Results>
        /// Vrify DELETE operation is successful with JSON response and  STATUS CODE = 200
        /// </Expected_Results>

        #endregion
        [Test, Description("DELTE request to remove projects Cache details")]
        public void CiricleCI_Projects_Cache_DEL()
        {
            APIRequest API = new APIRequest();

            var client = new RestClient(API.URL + "{Role}/{vcs-type}/{username}/{project}/{build}");
            var request = API.BuildDELETERequest();

            var fullUrl = client.BuildUri(request);
            var response = client.Execute(request);

            extent.LogRequest(fullUrl, Method.DELETE.ToString());
            extent.LogResponse(response);

            string jsonResponse = API.jsonDeserialize(response, "status");

            Assert.That(jsonResponse, Is.EqualTo("build dependency caches deleted"));
            extent.SetStepStatusInfo("JSON Response");
            extent.SetStepStatusPass(jsonResponse);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

        }


    }

}
