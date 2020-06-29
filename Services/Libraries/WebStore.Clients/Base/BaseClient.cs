using Microsoft.Extensions.Configuration;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace WebStore.Clients.Base
{
    public abstract class BaseClient
    {
        protected readonly string ServiceAddress;
        protected readonly HttpClient Client;

        #region Ctor

        protected BaseClient(IConfiguration configuration, string serviceAddress)
        {
            this.ServiceAddress = serviceAddress;

            Client = new HttpClient
            {
                BaseAddress = new Uri(configuration["WebApiURL"]),
                DefaultRequestHeaders =
                {
                    Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
                }
            };
        } 
        #endregion


        #region GET

        public T Get<T>(string url) => GetAsync<T>(url).Result;
        public async Task<T> GetAsync<T>(string url, CancellationToken Cancel = default)
        {
            var response = await Client.GetAsync(url, Cancel);
            return await response.EnsureSuccessStatusCode().Content.ReadAsAsync<T>(Cancel);
        }
        #endregion

        #region POST

        public HttpResponseMessage Post<T>(string url, T item) => PostAsync(url, item).Result;
        public async Task<HttpResponseMessage> PostAsync<T>(string url, T item, CancellationToken Cancel = default)
        {
            var response = await Client.PostAsJsonAsync(url, item, Cancel);
            return response.EnsureSuccessStatusCode();
        }
        #endregion

        #region PUT

        public HttpResponseMessage Put<T>(string url, T item) => PutAsync(url, item).Result;
        public async Task<HttpResponseMessage> PutAsync<T>(string url, T item, CancellationToken Cancel = default)
        {
            var response = await Client.PutAsJsonAsync(url, item, Cancel);
            return response.EnsureSuccessStatusCode();
        }
        #endregion

        #region DELETE

        public HttpResponseMessage Delete(string url) => DeleteAsync(url).Result;
        public async Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken Cancel = default) =>
            await Client.DeleteAsync(url, Cancel); 
        #endregion
    }
}