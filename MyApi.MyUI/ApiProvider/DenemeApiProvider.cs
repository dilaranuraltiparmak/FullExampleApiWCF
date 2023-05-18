using MyApi.MyUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApi.MyUI.ApiProvider
{
    public class DenemeApiProvider
    {
        HttpClient _httpClient;
        public DenemeApiProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// {
        ////  "productID": 17,
        //  "productName": "Alice Mutton"
        //}
        /// </summary>

        public async Task<List<ProductDTO>> VerileriGetir()
        {
            List<ProductDTO> listem = null;
            var responseMessage = await _httpClient.GetAsync("deneme");
            if (responseMessage.IsSuccessStatusCode)
            {
                listem = JsonConvert.DeserializeObject<List<ProductDTO>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return listem;
        }
    }
}
