using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NGitHub.Extras.Models {
    [JsonObject]
    public class RepositorySearchResults {
        [JsonProperty("repositories")]
        public List<RepositorySearchResult> Repositories { get; set; }
    }

    [JsonObject]
    public class RepositorySearchResult {
        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("forks")]
        public int Forks { get; set; }

        [JsonProperty("watchers")]
        public int Watchers { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("pushed_at")]
        public DateTime PushedAt { get; set; }

        [JsonProperty("fork")]
        public bool IsFork { get; set; }

        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; }

        [JsonProperty("open_issues")]
        public int OpenIssues { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("has_downloads")]
        public bool HasDownloads { get; set; }

        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }

        [JsonProperty("homepage")]
        public string HomePage { get; set; }
    }
}
