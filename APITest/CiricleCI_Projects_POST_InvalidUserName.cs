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
        /// Send POST API request to get followed project with In Valid API KEY
        /// </Scenario>

        /// <Expected_Results>
        /// Vrify POST operation is un successful with JSON response and  STATUS CODE = 404
        /// </Expected_Results>

        #endregion
        [Test, Description("POST request to Fetch all followed projects with Invalid User Name")]
        public void CiricleCI_Projects_POST_InvalidUserName()
        {
            APIRequest API = new APIRequest();


            var client = new RestClient(API.URL + "project/{vcs-type}/{username}/{project}/{build}");
            var request = API.BuildPOSTRequest("Sarfraz");

            var fullUrl = client.BuildUri(request);
            var response = client.Execute(request);

            extent.LogRequest(fullUrl, Method.POST.ToString());
            extent.LogResponse(response);

            string jsonResponse = API.jsonDeserialize(response, "message");

            Assert.That(jsonResponse.Contains("Not Found"));
            extent.SetStepStatusInfo("JSON Response");
            extent.SetStepStatusPass(jsonResponse);

            Assert.That((int)response.StatusCode, Is.EqualTo(404));

        }

    }

}
