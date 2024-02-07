using CodeAssignment_QA_AjayAL.Models;
using RestSharp;

namespace CodeAssignment_QA_AjayAL.Utilities
{
    internal static class APISetup
    {
        static string baseUrl = "https://www.localhost:8080/api/account";
        public static RestResponse PostApiRequest(RequestDetails requestDetails)
        {
            RestClient restClient = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl + "/create", Method.Post);
            restRequest.AddBody(requestDetails, ContentType.Json);
            RestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public static RestResponse DeleteApiRequest(string accountId)
        {
            RestClient restClient = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl + "/delete/" + accountId, Method.Delete);
            RestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public static RestResponse PutApiRequest(RequestDetails requestDetails, string endPoint)
        {
            RestClient restClient = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl + endPoint, Method.Put);
            restRequest.AddBody(requestDetails, ContentType.Json);
            RestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public static RestResponse GetApiRequest(RequestDetails requestDetails)
        {
            RestClient restClient = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
            restRequest.AddBody(requestDetails, ContentType.Json);
            RestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }
    }
}
