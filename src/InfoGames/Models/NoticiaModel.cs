using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoGames.Models {
    [Table("Noticias")]
    public class NoticiaModel {
        [Display(Name = "Id (referencia interna")]
        [Key] public required string Id { get; set; }

        [Display(Name = "Id do jogo (FK)")]
        [Required(ErrorMessage = "Obrigatório informar o Id (key) do Jogo")]
        public required string JogoId { get; set; }

        [ForeignKey("JogoId")]
        [Required(ErrorMessage = "Obrigatório informar o Jogo")]
        public required JogoModel Jogo { get; set; }

        [Display(Name = "Id do Jogo (referencia na Steam)")]
        public string? AppId { get; set; }

        [Display(Name = "Título")]
        public string? Titulo { get; set; }

        [Display(Name = "Url")]
        public string? Url { get; set; }

        [Display(Name = "É uma URL externa?")]
        public bool? IsExternalUrl { get; set; }

        [Display(Name = "Autor")]
        public string? Autor { get; set; }

        [Display(Name = "Thumbnail")]
        public string? Thumbnail { get; set; }

        [Display(Name = "Conteúdo")]
        public string? Conteudo { get; set; }

        [Display(Name = "Titulo da Notícia, no feed")]
        public string? NomeNoFeed { get; set; }

        [Display(Name = "Data")]
        public string? Data { get; set; }
    }
}
