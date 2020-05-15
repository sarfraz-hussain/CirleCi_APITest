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
        /// Send POST API request to get followed project with Valid API KEY
        /// </Scenario>

        /// <Expected_Results>
        /// Vrify POST operation is successful with JSON response and  STATUS CODE = 200
        /// </Expected_Results>

        #endregion

        [Test, Description("POST request to Fetch all followed projects")]
        public void CiricleCI_Projects_POST()
        {
            APIRequest API = new APIRequest();


            var client = new RestClient(API.URL + "project/{vcs-type}/{username}/{project}/{build}");
            var request = API.BuildPOSTRequest();

            var fullUrl = client.BuildUri(request);
            var response = client.Execute(request);

            extent.LogRequest(fullUrl, Method.POST.ToString());
            extent.LogResponse(response);

            Assert.That((int)response.StatusCode, Is.EqualTo(200));

        }



    }

}
