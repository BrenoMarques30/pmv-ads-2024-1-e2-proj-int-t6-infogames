using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace InfoGames.Models.Steam {
    public class AppNewsScheme {
        [JsonProperty("appnews", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("appnews")]
        public NewsData? NewsData { get; set; }
    }

    public class NewsData {
        [JsonProperty("appid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("appid")]
        public string? Appid { get; set; }

        [JsonProperty("newsitems", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("newsitems")]
        public List<NewsItems>? NewsItems { get; set; }

        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("count")]
        public string? Count { get; set; }
    }

    public class NewsItems {
        [JsonProperty("gid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("gid")]
        public string? Gid { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonProperty("is_external_url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_external_url")]
        public bool? IsExternalUrl { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [JsonProperty("contents", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contents")]
        public string? Contents { get; set; }

        [JsonProperty("feedlabel", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("feedlabel")]
        public string? FeedLabel { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonProperty("feedname", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("feedname")]
        public string? FeedName { get; set; }

        [JsonProperty("feed_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("feed_type")]
        public string? FeedType { get; set; }

        [JsonProperty("appid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("appid")]
        public string? Appid { get; set; }
    }
}
