using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubApp.Service
{
    public class GitHubService
    {
        private HttpClient _client;

        public GitHubService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.github.com/users");

            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

            _client = client;
        }

        public async Task<List<User>> GetUsers()
        {
            var response = await _client.GetAsync("users");
            return await response.Content.ReadAsAsync<List<User>>();
        }
    }
}
