using Newtonsoft.Json;
using NorthwindPwa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NorthwindPwa.Data
{
    public class ProductsService
    {
        private readonly string address = "https://northwind.now.sh/api/products";

        HttpClient _httpClient;
        public ProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetProductsAsync()
        {

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(address),
                Method = HttpMethod.Get
            };

            request.Headers.Add("mode", "no-cors");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            List<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json).ToList();
            return products;
        }
    }
}
