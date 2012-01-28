using System;
using NGitHub.Models;
using System.Collections.Generic;

namespace NGitHub.Extras.Services {
    public interface ISearchService {
        GitHubRequestAsyncHandle SearchUsersAsync(string user,
                                                  Action<IEnumerable<User>> callback,
                                                  Action<GitHubException> onError);

        GitHubRequestAsyncHandle SearchRepositoriesAsync(string repo,
                                                         Action<IEnumerable<Repository>> callback,
                                                         Action<GitHubException> onError);
    }
}