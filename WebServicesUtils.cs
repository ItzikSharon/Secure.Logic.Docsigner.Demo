using System.Net.Http.Headers;
using System.Text;

namespace Secure.Logic.Docsigner.Demo
{
    public class WebServicesUtils
    {
        public static async Task<string> PostTimedOutRequestJWTAsync(string apiUrl, string payload, int timeInSeconds=10, string jwt_token=null)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, timeInSeconds);
            
            if(jwt_token!= null){
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt_token);
            }
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            return result;
        }

    }
}
