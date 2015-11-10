using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Stash.Api.Converters;
using Newtonsoft.Json;

namespace Atlassian.Stash.Api.Entities
{
    public class Comment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("author")]
        public User Author { get; set; }
        [JsonProperty("comments")]
        public Comment[] Comments { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("createdDate")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("updatedDate")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime UpdatedDate { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
