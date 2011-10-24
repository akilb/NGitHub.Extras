using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;
using NGitHub.Extras.Models;
using NGitHub.Extras.Utility;
using NGitHub.Helpers;
using NGitHub.Web;
using RestSharp;

namespace NGitHub.Extras.Services {
    public class FeedService : IFeedService {
        private readonly IGitHubClient _client;
        private readonly IRestClientFactory _factory;

        public FeedService(IGitHubClient client)
            : this(client, new RestClientFactory()) {
        }

        public FeedService(IGitHubClient client, IRestClientFactory factory) {
            Ensure.ArgumentNotNull(client, "client");
            Ensure.ArgumentNotNull(factory, "factory");

            _client = client;
            _factory = factory;
        }

        public void GetUserActivityAsync(string user,
                                         Action<IEnumerable<FeedItem>> callback,
                                         Action<GitHubException> onError) {
            Ensure.ArgumentNotNull(user, "user");

            GetFeedItemsAsync(string.Format("{0}.atom", user), callback, onError);
        }

        public void GetUserNewsFeedAsync(string user,
                                         Action<IEnumerable<FeedItem>> callback,
                                         Action<GitHubException> onError) {
            Ensure.ArgumentNotNull(user, "user");

            GetFeedItemsAsync(string.Format("{0}.private.atom", user), callback, onError);
        }

        private void GetFeedItemsAsync(string resource,
                                       Action<IEnumerable<FeedItem>> callback,
                                       Action<GitHubException> onError) {
            Ensure.ArgumentNotNull(callback, "callback");
            Ensure.ArgumentNotNull(onError, "onError");

            var client = _factory.CreateRestClient(Constants.GitHubUrl);
            client.Authenticator = _client.Authenticator;

            var request = new RestRequest(resource,RestSharp.Method.GET);
            client.ExecuteAsync(request,
                                (r, h) => {
                                    if (r.StatusCode != HttpStatusCode.OK) {
                                        onError(new GitHubException(new GitHubResponse(r), ErrorType.Unknown));
                                        return;
                                    }

                                    using (var tr = new StringReader(r.Content))
                                    using (var reader = XmlReader.Create(tr)) {
                                        var feedItems = SyndicationFeed.Load(reader).Items.Select(i => new FeedItem(i));
                                        callback(feedItems ?? new List<FeedItem>());
                                    }
                                });
        }
    }
}
