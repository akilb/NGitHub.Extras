using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NGitHub.Models;

namespace NGitHub.Extras.Models {
    [JsonObject]
    public class UserSearchResults {
        [JsonProperty("users")]
        public List<UserSearchResult> Users { get; set; }
    }

    [JsonObject]
    public class UserSearchResult {
        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("public_repo_count")]
        public int PublicRepoCount { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }
    }
}
