using GitHubUserSearchApp.Model;

namespace GitHubUserSearchApp.Sdk.Abstractions
{
    public interface IGithubUserApi
    {
        Task<GithubUser> GetGithubUser(string name);
    }
}
