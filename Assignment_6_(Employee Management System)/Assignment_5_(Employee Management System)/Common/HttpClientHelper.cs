using System.Text;

namespace Assignment_5__Employee_Management_System_.Common
{
    public class HttpClientHelper
    {
        public static async Task<string> MakePostResq(string baseUrl, string endpoint, string ApiRequest)
        {
            var Sockethanlder = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                MaxConnectionsPerServer = 10
            };
            using (HttpClient httpClient = new HttpClient(Sockethanlder))
            {
                httpClient.Timeout = TimeSpan.FromMinutes(5);
                httpClient.BaseAddress = new Uri(baseUrl);
                StringContent ApiRequestContent = new StringContent(ApiRequest, Encoding.UTF8, "application/json");

                var httpResp = httpClient.PostAsync(endpoint, ApiRequestContent).Result;
                var httpRespString = httpResp.Content.ReadAsStringAsync().Result;

                if (!httpResp.IsSuccessStatusCode)
                    throw new Exception(httpRespString);
                return httpRespString;
            }
        }
        public static async Task<string> MakeGetResq(string baseUrl, string endpoint)
        {
            var SocketHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                MaxConnectionsPerServer = 10
            };
            using (HttpClient httpClient = new HttpClient(SocketHandler))
            {
                httpClient.Timeout = TimeSpan.FromMinutes(5);
                httpClient.BaseAddress = new Uri(baseUrl);

                var Httpresp = await httpClient.GetAsync(endpoint);
                var HttprespString = await Httpresp.Content.ReadAsStringAsync();

                if (!Httpresp.IsSuccessStatusCode)
                    throw new Exception(HttprespString);
                return HttprespString;
            }
        }
    }
}
