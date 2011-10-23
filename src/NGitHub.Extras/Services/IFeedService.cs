using System;
using System.Collections.Generic;
using NGitHub.Extras.Models;

namespace NGitHub.Extras.Services {
    public interface IFeedService {
        void GetUserActivityAsync(string user,
                                  Action<IEnumerable<FeedItem>> callback,
                                  Action<GitHubException> onError);
        void GetUserNewsFeedAsync(string user,
                                  Action<IEnumerable<FeedItem>> callback,
                                  Action<GitHubException> onError);
    }
}
