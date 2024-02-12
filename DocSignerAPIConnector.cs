using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace com.slg.docsigner.demo
{
    public class DocSignerAPIConnector
    {
        public static APISettings Settings = new APISettings();


        public static async Task<DSAPI_MSG_OUT_STATUS> STATUS()
        {
            string finalURL = $"{Settings.BaseURL}/status";

            HttpClient httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
            string responseAsJson = await httpResponse.Content.ReadAsStringAsync();

            //Desirialize response 
            DSAPI_MSG_OUT_STATUS rv = JsonConvert.DeserializeObject<DSAPI_MSG_OUT_STATUS>(responseAsJson);
            return rv;
        }

        public static async Task<DSAPI_MSG_OUT_LOGIN> APILogin(DSAPI_MSG_IN_LOGIN request)
        {
            string finalURL = $"{Settings.BaseURL}/login";
            string requestAsJson = JsonConvert.SerializeObject(request);

            HttpClient httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
            httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
            string responseAsJson = await httpResponse.Content.ReadAsStringAsync();

            //Desirialize response 
            DSAPI_MSG_OUT_LOGIN rv = JsonConvert.DeserializeObject<DSAPI_MSG_OUT_LOGIN>(responseAsJson);
            return rv;
        }


        public static async Task<DSAPI_MSG_OUT_CREATE_ENVELOPE> CreateEnvelope(DSAPI_MSG_IN_CREATE_ENVELOPE request, string authToken)
        {
            string finalURL = $"{Settings.BaseURL}/create_envelope";
            string requestAsJson = JsonConvert.SerializeObject(request);

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, finalURL);
            httpRequest.Content = new StringContent(requestAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
            string responseAsJson = await httpResponse.Content.ReadAsStringAsync();

            //Desirialize response 
            DSAPI_MSG_OUT_CREATE_ENVELOPE rv = JsonConvert.DeserializeObject<DSAPI_MSG_OUT_CREATE_ENVELOPE>(responseAsJson);
            return rv;
        }

    }
}
