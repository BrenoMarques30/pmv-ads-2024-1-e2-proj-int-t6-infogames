using System.ComponentModel.DataAnnotations;

namespace InfoGames.Models {
    public class LojaModel {

        [Key] public required string Id { get; set; }
        public string? Nome { get; set; }
        public string? Url { get; set; }
        public string? Logo { get; set; }
        public string? ChaveApi { get; set; }
    }
}
