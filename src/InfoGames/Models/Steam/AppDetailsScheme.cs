using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace InfoGames.Models.Steam {
    public class AppDetailsScheme {
    }
    public class RootDetails {
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("success")]
        public bool? Success { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public Data? Data { get; set; }
    }

    public class Category {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }

    public class ContentDescriptors {
        [JsonProperty("ids", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ids")]
        public List<string?>? Ids { get; set; }

        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }
    }

    public class Data {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonProperty("steam_appid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("steam_appid")]
        public string? Appid { get; set; }

        [JsonProperty("required_age", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("required_age")]
        public string? RequiredAge { get; set; }

        [JsonProperty("is_free", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_free")]
        public bool? IsFree { get; set; }

        [JsonProperty("controller_support", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("controller_support")]
        public string? ControllerSupport { get; set; }

        [JsonProperty("detailed_description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("detailed_description")]
        public string? DetailedDescription { get; set; }

        [JsonProperty("about_the_game", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("about_the_game")]
        public string? AboutTheGame { get; set; }

        [JsonProperty("short_description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("short_description")]
        public string? ShortDescription { get; set; }

        [JsonProperty("supported_languages", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("supported_languages")]
        public string? SupportedLanguages { get; set; }

        [JsonProperty("header_image", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("header_image")]
        public string? HeaderImage { get; set; }

        [JsonProperty("capsule_image", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("capsule_image")]
        public string? CapsuleImage { get; set; }

        [JsonProperty("capsule_imagev5", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("capsule_imagev5")]
        public string? CapsuleImagev5 { get; set; }

        [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("website")]
        public string? Website { get; set; }

        [JsonProperty("legal_notice", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("legal_notice")]
        public string? LegalNotice { get; set; }

        [JsonProperty("recommendations", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("recommendations")]
        public Recommendations? Recommendations { get; set; }

        [JsonProperty("background", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("background")]
        public string? Background { get; set; }

        [JsonProperty("background_raw", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("background_raw")]
        public string? BackgroundRaw { get; set; }

        [JsonProperty("dlc", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("dlc")]
        public List<string>? Dlc { get; set; }

        [JsonProperty("developers", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("developers")]
        public List<string>? Developers { get; set; }

        [JsonProperty("publishers", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("publishers")]
        public List<string>? Publishers { get; set; }

        [JsonProperty("packages", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("packages")]
        public List<string>? Packages { get; set; }

        [JsonProperty("fullgame", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("fullgame")]
        public FullGame? FullGame { get; set; }

        [JsonProperty("pc_requirements", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("pc_requirements")]
        public RequirementsOrEmptyArray? PcRequirements { get; set; }

        [JsonProperty("mac_requirements", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mac_requirements")]
        public RequirementsOrEmptyArray? MacRequirements { get; set; }

        [JsonProperty("linux_requirements", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("linux_requirements")]
        public RequirementsOrEmptyArray? LinuxRequirements { get; set; }

        [JsonProperty("price_overview", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("price_overview")]
        public PriceOverview? PriceOverview { get; set; }

        [JsonProperty("package_groups", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("package_groups")]
        public List<PackageGroup>? PackageGroups { get; set; }

        [JsonProperty("platforms", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("platforms")]
        public Platforms? Platforms { get; set; }

        [JsonProperty("metacritic", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("metacritic")]
        public Metacritic? Metacritic { get; set; }

        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("categories")]
        public List<Category>? Categories { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("genres")]
        public List<Genre>? Genres { get; set; }

        [JsonProperty("screenshots", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("screenshots")]
        public List<Screenshot>? Screenshots { get; set; }

        [JsonProperty("movies", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("movies")]
        public List<Movie>? Movies { get; set; }

        [JsonProperty("achievements", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("achievements")]
        public Achievements? Achievements { get; set; }

        [JsonProperty("release_date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("release_date")]
        public ReleaseDate? ReleaseDate { get; set; }

        [JsonProperty("support_info", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("support_info")]
        public SupportInfo? SupportInfo { get; set; }

        [JsonProperty("content_descriptors", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("content_descriptors")]
        public ContentDescriptors? ContentDescriptors { get; set; }

        [JsonProperty("ratings", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ratings")]
        public Ratings? Ratings { get; set; }

        [JsonProperty("demos", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("demos")]
        public List<Demos?>? Demos { get; set; }
    }

    public class Dejus {
        [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rating")]
        public string? Rating { get; set; }

        [JsonProperty("descriptors", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("descriptors")]
        public string? Descriptors { get; set; }

        [JsonProperty("use_age_gate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("use_age_gate")]
        public string? UseAgeGate { get; set; }

        [JsonProperty("required_age", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("required_age")]
        public string? RequiredAge { get; set; }
    }

    public class Recommendations {
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("total")]
        public string? Total { get; set; }
    }

    public class FullGame {
        [JsonProperty("appid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("appid")]
        public required string Appid { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }

    public class Demos {
        [JsonProperty("appid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("appid")]
        public string? Appid { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }

    public class Genre {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }

    public class Achievements {
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("total")]
        public string? Total { get; set; }

        [JsonProperty("highlighted", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("highlighted")]
        public List<Highlighted>? Highlighted { get; set; }
    }

    public class Highlighted {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("path")]
        public string? Path { get; set; }
    }

    public class RequirementsOrEmptyArray {
        public Requirements? Requirements { get; set; }
        public List<string?>? EmptyArray { get; set; }
    }

    public class Requirements {
        [JsonProperty("minimum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("minimum")]
        public string? Minimum { get; set; }

        [JsonProperty("recommended", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("recommended")]
        public string? Recommended { get; set; }
    }

    public class RequirementsConverter : Newtonsoft.Json.JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(RequirementsOrEmptyArray);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) {
            RequirementsOrEmptyArray result = new RequirementsOrEmptyArray();

            if (reader.TokenType == JsonToken.StartArray) {
                // If it's an array, read it as an array of strings
                result.EmptyArray = serializer.Deserialize<List<string?>>(reader) ?? new List<string?>();
            } else if (reader.TokenType == JsonToken.StartObject) {
                // If it's an object, deserialize it as Requirements
                result.Requirements = serializer.Deserialize<Requirements>(reader);
            } else {
                throw new JsonReaderException($"Unexpected token type: {reader.TokenType}. Expected StartArray or StartObject.");
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            throw new NotImplementedException();
        }

    }

    public class Movie {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }

        [JsonProperty("webm", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("webm")]
        public Webm? Webm { get; set; }

        [JsonProperty("mp4", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mp4")]
        public Mp4? Mp4 { get; set; }

        [JsonProperty("highlight", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("highlight")]
        public bool Highlight { get; set; }
    }

    public class Mp4 {
        [JsonProperty("480", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("480")]
        public string? _480 { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("max")]
        public string? Max { get; set; }
    }

    public class PackageGroup {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonProperty("selection_text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("selection_text")]
        public string? SelectionText { get; set; }

        [JsonProperty("save_text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("save_text")]
        public string? SaveText { get; set; }

        [JsonProperty("display_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("display_type")]
        public string? DisplayType { get; set; }

        [JsonProperty("is_recurring_subscription", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_recurring_subscription")]
        public string? IsRecurringSubscription { get; set; }

        [JsonProperty("subs", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("subs")]
        public List<Sub>? Subs { get; set; }
    }

    public class Platforms {
        [JsonProperty("windows", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("windows")]
        public bool? Windows { get; set; }

        [JsonProperty("mac", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mac")]
        public bool? Mac { get; set; }

        [JsonProperty("linux", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("linux")]
        public bool? Linux { get; set; }
    }

    public class PriceOverview {
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonProperty("initial", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("initial")]
        public string? Initial { get; set; }

        [JsonProperty("final", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("final")]
        public string? Final { get; set; }

        [JsonProperty("discount_percent", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("discount_percent")]
        public string? DiscountPercent { get; set; }

        [JsonProperty("initial_formatted", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("initial_formatted")]
        public string? InitialFormatted { get; set; }

        [JsonProperty("final_formatted", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("final_formatted")]
        public string? FinalFormatted { get; set; }
    }

    public class Ratings {
        [JsonProperty("dejus", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("dejus")]
        public Dejus? Dejus { get; set; }
    }

    public class ReleaseDate {
        [JsonProperty("coming_soon", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("coming_soon")]
        public bool ComingSoon { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("date")]
        public string? Date { get; set; }
    }

    public class Screenshot {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonProperty("path_thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("path_thumbnail")]
        public required string PathThumbnail { get; set; }

        [JsonProperty("path_full", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("path_full")]
        public required string PathFull { get; set; }
    }

    public class Sub {
        [JsonProperty("packageid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("packageid")]
        public string? Packageid { get; set; }

        [JsonProperty("percent_savings_text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("percent_savings_text")]
        public string? PercentSavingsText { get; set; }

        [JsonProperty("percent_savings", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("percent_savings")]
        public string? PercentSavings { get; set; }

        [JsonProperty("option_text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("option_text")]
        public string? OptionText { get; set; }

        [JsonProperty("option_description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("option_description")]
        public string? OptionDescription { get; set; }

        [JsonProperty("can_get_free_license", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("can_get_free_license")]
        public string? CanGetFreeLicense { get; set; }

        [JsonProperty("is_free_license", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_free_license")]
        public bool? IsFreeLicense { get; set; }

        [JsonProperty("price_in_cents_with_discount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("price_in_cents_with_discount")]
        public string? PriceInCentsWithDiscount { get; set; }
    }

    public class Metacritic {
        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("score")]
        public string? Score { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public class SupportInfo {
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }

    public class Webm {
        [JsonProperty("480", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("480")]
        public string? _480 { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("max")]
        public string? Max { get; set; }
    }
}
