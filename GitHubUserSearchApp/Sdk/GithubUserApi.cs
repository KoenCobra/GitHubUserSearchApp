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

        public async Task<ServiceResponse<GithubUser>> GetGithubUser(string name)
        {
            var userResponse = new ServiceResponse<GithubUser>();

            var response = await _httpClient.GetAsync($"https://api.github.com/users/{name}");

            await using var content = await response.Content.ReadAsStreamAsync();

            var user = await JsonSerializer.DeserializeAsync<GithubUser>(content);

            if (user != null && user.id == 0)
            {
                userResponse.Succes = false;
                userResponse.Message = "No result";
            }
            else
            {
                userResponse.Data = user;
            }

            return userResponse;
        }
    }
}
