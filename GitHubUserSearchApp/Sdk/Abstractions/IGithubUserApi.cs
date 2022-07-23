using GitHubUserSearchApp.Model;

namespace GitHubUserSearchApp.Sdk.Abstractions
{
    public interface IGithubUserApi
    {
        Task<ServiceResponse<GithubUser>> GetGithubUser(string name);
    }
}
