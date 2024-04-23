using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoGames.Models {
    [Table("Lojas")]
    public class Loja {
        [Key]
        public required string Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        public required string Nome { get; set; }

        public string? Url { get; set; }

        public string? Logo { get; set; }

        public string? ChaveApi { get; set; }

        public ICollection<Jogo>? Jogos { get; set; }
    }
}
