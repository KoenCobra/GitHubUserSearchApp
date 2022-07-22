using System.Text.Json;
using GitHubUserSearchApp.Model;
using GitHubUserSearchApp.Sdk.Abstractions;

namespace GitHubUserSearchApp.Sdk
{
    public class GithubUserApi : IGithubUserApi
    {
        private readonly HttpClient _httpClient;

        public GithubUserApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GithubUser> GetGithubUser(string name)
        {
            var response = await _httpClient.GetAsync($"https://api.github.com/users/{name}");

            //response.EnsureSuccessStatusCode();

            await using var content = await response.Content.ReadAsStreamAsync();

            var user = await JsonSerializer.DeserializeAsync<GithubUser>(content);

            if (user is null)
            {
                return user = new GithubUser();
            }

            return user;    
        }
    }
}
