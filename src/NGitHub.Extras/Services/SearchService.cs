using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NGitHub.Extras.Utility;
using NGitHub.Models;
using NGitHub.Web;
using NGitHub.Extras.Models;

namespace NGitHub.Extras.Services {
    public class SearchService : ISearchService {
        private readonly IGitHubClient _client;

        public SearchService(IGitHubClient client) {
            Ensure.ArgumentNotNull(client, "client");

            _client = client;
        }
        public GitHubRequestAsyncHandle SearchUsersAsync(string query,
                                                         Action<IEnumerable<User>> callback,
                                                         Action<GitHubException> onError) {
            Ensure.ArgumentNotNull(query, "user");

            var resource = string.Format("/user/search/{0}", query.Replace(' ', '+'));
            var request = new GitHubRequest(resource, API.v2, Method.GET);
            return _client.CallApiAsync<UserSearchResults>(
                        request,
                        r => callback(r.Data.Users.Select(u => new User {
                                                            Login = u.Login,
                                                            Name = u.Name,
                                                            PublicRepos = u.PublicRepoCount,
                                                            Location = u.Location,
                                                            GravatarId = u.GravatarId,
                                                            Type = u.Type,
                                                            Followers = u.Followers
                                                          })),
                        onError);
        }

        public GitHubRequestAsyncHandle SearchRepositoriesAsync(string repo,
                                                                Action<IEnumerable<Repository>> callback,
                                                                Action<GitHubException> onError) {
            Ensure.ArgumentNotNull(repo, "repo");

            var resource = string.Format("/repos/search/{0}", repo.Replace(' ', '+'));
            var request = new GitHubRequest(resource, API.v2, Method.GET);
            return _client.CallApiAsync<RepositorySearchResults>(
                        request,
                        resp => callback(resp.Data.Repositories.Select(
                                    r => new Repository {
                                            Owner = new User {
                                                        Login = r.Owner
                                                    },
                                            Name = r.Name,
                                            Description = r.Description,
                                            Language = r.Language,
                                            NumberOfForks = r.Forks,
                                            NumberOfWatchers = r.Watchers,
                                            Url = r.Url,
                                            CreatedDate = r.CreatedAt,
                                            LastUpdatedDate = r.PushedAt,
                                            IsFork = r.IsFork,
                                            IsPrivate = r.IsPrivate,
                                            OpenIssues = r.OpenIssues,
                                            HomePage = r.HomePage,
                                            Size = r.Size,
                                        })),
                        onError);
        }
    }
}
