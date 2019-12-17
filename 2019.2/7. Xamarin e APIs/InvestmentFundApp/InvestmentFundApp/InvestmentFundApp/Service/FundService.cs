using InvestmentFundApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentFundApp.Service
{
    public class FundService
    {
        public FundService( )
        {
 
        }

        public async Task<List<Fund>> GetAll()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://192.168.1.14:45457/api/Fund");
                return JsonConvert.DeserializeObject<List<Fund>>(result);
            }
        }

        public async Task<List<Fund>> GetByName(string name)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://192.168.1.14:45457/api/Fund/"+ name);
                return JsonConvert.DeserializeObject<List<Fund>>(result);
            }
        }
        
        public async Task Post(Fund fund)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(fund);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("http://192.168.1.14:45457/api/Fund", content);
                // Se ocorrer um erro lança uma exceção
                result.EnsureSuccessStatusCode();
            }
        }
    }
}
