using System.Net.Http.Headers;

namespace DataAccess
{
    public class ApiConnection
    {
        private readonly HttpClient _httpClient;

        public ApiConnection(string baseAddress)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Asynchronously sends a GET request to the specified API endpoint and retrieves the response content as a string.
        /// </summary>
        /// <param name="endpoint">The API endpoint to send the GET request.</param>
        /// <returns>A Task representing the asynchronous operation that, upon completion, returns the response content as a string</returns>
        public async Task<string> GetAsync(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
