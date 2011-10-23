using NGitHub.Extras.Services;

namespace NGitHub.Extras {
    public static class GitHubClientExtensions {
        public static IFeedService GetFeedService(this IGitHubClient client) {
            return new FeedService(client);
        }
    }
}