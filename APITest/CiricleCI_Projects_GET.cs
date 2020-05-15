using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APItestRestSharp
{
    #region Test Description

    /// <Scenario>
    /// Send API request to GET project detail with Valid API KEY
    /// </Scenario>

    /// <Expected_Results>
    /// Vrify GET operation is successful with JSON response and  STATUS CODE = 200
    /// </Expected_Results>

    #endregion
    public partial class Tests: TestBase
    {
        [Test, Description("GET request to Fetch all projects detail")]
        public void CiricleCI_Projects_GET()
        {
            APIRequest API = new APIRequest();

            var client = new RestClient(API.URL);
            var request = API.BuildGETRequest("projects");

            var fullUrl = client.BuildUri(request);
            var response = client.Execute(request);

            extent.LogRequest(fullUrl, Method.GET.ToString());
            extent.LogResponse(response);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

        }

    }

}
