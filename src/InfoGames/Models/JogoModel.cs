using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoGames.Models {
    public class JogoModel {
        [Key] public required string Id { get; set; }
        public required string AppId { get; set; }
        public required string Nome { get; set; }
        public DetalhesJogo? Detalhes { get; set; }
    }

    public class DetalhesJogo {
        [Key] public required string Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public required int SteamAppId { get; set; }
        public string? RequiredAge { get; set; }
        public bool? IsFree { get; set; }
        public string? DetailedDescription { get; set; }
        public string? AboutTheGame { get; set; }
        public string? ShortDescription { get; set; }
        public string? SupportedLanguages { get; set; }
        public string? HeaderImage { get; set; }
        public string? CapsuleImage { get; set; }
        public string? CapsuleImagev5 { get; set; }
        public string? Website { get; set; }
        public string? Background { get; set; }
        public string? BackgroundRaw { get; set; }
    }

    public class Fullgame {
        public required string FullGameAppId { get; set; }
        public required string Name { get; set; }
    }

    public class PcRequirements {
        public string? Minimum { get; set; }
        public string? Recommended { get; set; }
    }

    public class MacRequirements {
        public string? Minimum { get; set; }
        public string? Recommended { get; set; }
    }

    public class LinuxRequirements {
        public string? Minimum { get; set; }
        public string? Recommended { get; set; }
    }
    public class PriceOverview {
        public string? Currency { get; set; }
        public int Initial { get; set; }
        public int Final { get; set; }
        public int DiscountPercent { get; set; }
        public string? InitialFormatted { get; set; }
        public string? FinalFormatted { get; set; }
    }

    public class PackageGroup {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? SelectionText { get; set; }
        public string? SaveText { get; set; }
        public int DisplayType { get; set; }
        public string? IsRecurringSubscription { get; set; }
        public List<Package>? Subs { get; set; }
    }

    public class Package {
        public int PackageId { get; set; }
        public string? PercentSavingsText { get; set; }
        public int PercentSavings { get; set; }
        public string? OptionText { get; set; }
        public string? OptionDescription { get; set; }
        public string? CanGetFreeLicense { get; set; }
        public bool IsFreeLicense { get; set; }
        public int PriceInCentsWithDiscount { get; set; }
    }

    public class Platforms {
        public bool Windows { get; set; }
        public bool Mac { get; set; }
        public bool Linux { get; set; }
    }

    public class Category {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

    public class Genre {
        public string? Id { get; set; }
        public string? Description { get; set; }
    }

    public class Screenshot {
        public int Id { get; set; }
        public string? PathThumbnail { get; set; }
        public string? PathFull { get; set; }
    }
    public class Movie {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Thumbnail { get; set; }
        public Webm? Webm { get; set; }
        public Mp4? Mp4 { get; set; }
        public bool Highlight { get; set; }
    }
    public class Webm {
        public string? _480 { get; set; }
        public string? Max { get; set; }
    }
    public class Mp4 {
        public string? _480 { get; set; }
        public string? Max { get; set; }
    }
    public class ReleaseDate {
        public bool ComingSoon { get; set; }
        public string? Date { get; set; }
    }
    public class SupportInfo {
        public string? Url { get; set; }
        public string? Email { get; set; }
    }
    public class ContentDescriptors {
        public List<int>? Ids { get; set; }
        public string? Notes { get; set; }
    }

    public class Ratings {
        public Dejus? Dejus { get; set; }
    }

    public class Dejus {
        public string? Rating { get; set; }
        public string? Descriptors { get; set; }
        public string? UseAgeGate { get; set; }
        public string? RequiredAge { get; set; }
    }
}
