using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoGames.Models {
    [Table("Jogos")]
    public class Jogo {
        [Key]
        public required string Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o AppId (Id do jogo na Loja)")]
        public required string AppId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Id da Loja")]
        public required string LojaId { get; set; }

        [ForeignKey("LojaId")]
        public required Loja Loja { get; set; }

        public DetalhesJogo? DetalhesJogo { get; set; }

    }
}
