using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoGames.Models {
    [Table("DetalhesJogos")]
    public class DetalhesJogo {

        [Display(Name = "Id (referencia interna")]
        [Key] public required string Id { get; set; }

        [Display(Name = "Id do Jogo (referencia na Steam)")]
        public required string IdJogo { get; set; }

        [ForeignKey("IdJogo")]
        [Required(ErrorMessage = "Obrigatório informar o jogo")]
        public required Jogo Jogo { get; set; }

        [Display(Name = "Tipo")]
        public string? Type { get; set; }

        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Display(Name = "Id do Jogo (referencia na Steam)")]
        public string? AppId { get; set; }

        [Display(Name = "Recomendação etária")]
        public string? RequiredAge { get; set; }

        [Display(Name = "É gratuito")]
        public bool? IsFree { get; set; }

        [Display(Name = "Suporte à Controle")]
        public string? ControllerSupport { get; set; }

        [Display(Name = "Descrição detalhada")]
        public string? DetailedDescription { get; set; }

        [Display(Name = "Sobre o jogo")]
        public string? AboutTheGame { get; set; }

        [Display(Name = "Descrição curta")]
        public string? ShortDescription { get; set; }

        [Display(Name = "Línguas disponíveis")]
        public string? SupportedLanguages { get; set; }

        [Display(Name = "Imagem Principal")]
        public string? HeaderImage { get; set; }

        [Display(Name = "Thumnail")]
        public string? CapsuleImage { get; set; }

        [Display(Name = "Thumbnailv5")]
        public string? CapsuleImagev5 { get; set; }

        [Display(Name = "Website")]
        public string? Website { get; set; }

        [Display(Name = "Notificação Legal")]
        public string? LegalNotice { get; set; }

        [Display(Name = "Número de Likes")]
        public string? RecommendationsTotal { get; set; }

        [Display(Name = "Imagem de fundo")]
        public string? Background { get; set; }

        [Display(Name = "Imagem de fundo, sem tratamento")]
        public string? BackgroundRaw { get; set; }

        [Display(Name = "DLCs")]
        public List<string>? Dlc { get; set; }

        [Display(Name = "Desenvolvedores")]
        public List<string>? Developers { get; set; }

        [Display(Name = "Editores")]
        public List<string>? Publishers { get; set; }

        [Display(Name = "Pacotes")]
        public List<string>? Packages { get; set; }

        [Display(Name = "Jogo Completo")]
        public JogoCompleto? JogoCompleto { get; set; }

        [Display(Name = "Requisitos de Hardware para Windows")]
        public RequisitoPC? RequisitoPC { get; set; }

        [Display(Name = "Requisitos de Hardware para Mac")]
        public RequisitoMac? RequisitoMac { get; set; }

        [Display(Name = "Requisitos de Hardware para Linux")]
        public RequisitoLinux? RequisitoLinux { get; set; }

        //[Display(Name = "Detalhes do preço")]
        //public ICollection<DetalhesPreco>? PriceOverview { get; set; }

        //[Display(Name = "Grupos de pacotes")]
        //public ICollection<GrupoDePacote>? PackageGroups { get; set; }

        //[Display(Name = "Plataformas")]
        //public ICollection<Plataformas>? Platforms { get; set; }

        //[Display(Name = "Metacrítica")]
        //public ICollection<Metacritica>? Metacritic { get; set; }

        //[Display(Name = "Categorias")]
        //public ICollection<Categoria>? Categories { get; set; }

        //[Display(Name = "Generos")]
        //public ICollection<Genero>? Genres { get; set; }

        //[Display(Name = "Fotos")]
        //public ICollection<Screenshot>? Screenshots { get; set; }

        //[Display(Name = "Filmes")]
        //public ICollection<Filme>? Movies { get; set; }

        //[Display(Name = "Conquista")]
        //public ICollection<Conquista>? Achievements { get; set; }

        //[Display(Name = "Data de lançamento")]
        //public ICollection<DataDeLancamento>? ReleaseDate { get; set; }

        //[Display(Name = "Informações de suporte")]
        //public ICollection<InformacaoDeSuporte>? SupportInfo { get; set; }

        //[Display(Name = "Descritores de conteúdo")]
        //public ICollection<DescritorDeConteudo>? ContentDescriptors { get; set; }

        //[Display(Name = "Classificações")]
        //public ICollection<Classificacao>? Ratings { get; set; }

        //[Display(Name = "Demonstrações")]
        //public ICollection<Demos>? Demos { get; set; }
    }

    [Table("JogosCompletos")]
    public class JogoCompleto {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Id do jogo completo")]
        public required string FullGameAppId { get; set; }

        [Display(Name = "Nome do jogo completo")]
        public required string Name { get; set; }
    }

    [Table("RequisitosPC")]
    public class RequisitoPC {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Requisitos Mínimos")]
        public string? Minimum { get; set; }

        [Display(Name = "Requisitos Recomendados")]
        public string? Recommended { get; set; }
    }

    [Table("RequisitosMac")]
    public class RequisitoMac {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Requisitos Mínimos")]
        public string? Minimum { get; set; }

        [Display(Name = "Requisitos Recomendados")]
        public string? Recommended { get; set; }
    }

    [Table("RequisitosLinux")]
    public class RequisitoLinux {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Requisitos Mínimos")]
        public string? Minimum { get; set; }

        [Display(Name = "Requisitos Recomendados")]
        public string? Recommended { get; set; }
    }

    [Table("DetalhesDePrecos")]
    public class DetalhesPreco {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Moeda")]
        public string? Currency { get; set; }

        [Display(Name = "Preço Inicial")]
        public string? Initial { get; set; }

        [Display(Name = "Preço Final")]
        public string? Final { get; set; }

        [Display(Name = "Desconto (%)")]
        public string? DiscountPercent { get; set; }

        [Display(Name = "Preço Inicial Formatado")]
        public string? InitialFormatted { get; set; }

        [Display(Name = "Preço Final Formatado")]
        public string? FinalFormatted { get; set; }
    }

    [Table("GruposDePacotes")]
    public class GrupoDePacote {

        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Display(Name = "Título")]
        public string? Title { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        [Display(Name = "Seleção de texto")]
        public string? SelectionText { get; set; }

        [Display(Name = "Salvar texto")]
        public string? SaveText { get; set; }

        [Display(Name = "Exibir tipo")]
        public string? DisplayType { get; set; }

        [Display(Name = "É assinatura recorrente")]
        public string? IsRecurringSubscription { get; set; }

        [Display(Name = "Pacotes")]
        public ICollection<Pacote>? Packages { get; set; }
    }

    [Table("Pacotes")]
    public class Pacote {
        [Key] public required string IdGrupoDePacote { get; set; }

        [ForeignKey("GrupoDePacoteId")]
        public required GrupoDePacote? GrupoDePacote { get; set; }

        [Display(Name = "Id do pacote (referencia na Steam)")]
        public string? PackageId { get; set; }

        [Display(Name = "Porcentagem do desconto (texto)")]
        public string? PercentSavingsText { get; set; }

        [Display(Name = "Porcentagem do desconto")]
        public string? PercentSavings { get; set; }

        [Display(Name = "Opção (texto)")]
        public string? OptionText { get; set; }

        [Display(Name = "Opção (descrição)")]
        public string? OptionDescription { get; set; }

        [Display(Name = "Licensa pode ser obtida gratuitamente?")]
        public string? CanGetFreeLicense { get; set; }

        [Display(Name = "Licensa é gratuita?")]
        public bool? IsFreeLicense { get; set; }

        [Display(Name = "Preço com desconto (em centavos)")]
        public string? PriceInCentsWithDiscount { get; set; }
    }

    [Table("Plataformas")]
    public class Plataformas {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Windows")]
        public bool Windows { get; set; }

        [Display(Name = "macOS")]
        public bool Mac { get; set; }

        [Display(Name = "Linux")]
        public bool Linux { get; set; }
    }

    [Table("Metacriticas")]
    public class Metacritica {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Pontuação")]
        public string? Score { get; set; }

        [Display(Name = "Link")]
        public string? Url { get; set; }
    }

    [Table("Categorias")]
    public class Categoria {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Id da Categoria (referencia na Steam)")]
        public string? IdCategoria { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }
    }

    [Table("Generos")]
    public class Genero {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }
    }

    [Table("Screenshots")]
    public class Screenshot {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "URL da thumbnail")]
        public required string PathThumbnail { get; set; }

        [Display(Name = "URL da imagem completa")]
        public required string PathFull { get; set; }
    }

    [Table("Filmes")]
    public class Filme {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Display(Name = "URL da thumbnail")]
        public string? Thumbnail { get; set; }

        [Display(Name = "Vídeo (Web movie)")]
        public ICollection<Midia>? Webm { get; set; }

        [Display(Name = "Vídeo (.mp4)")]
        public ICollection<Midia>? Mp4 { get; set; }

        [Display(Name = "Destacar?")]
        public bool Highlight { get; set; }
    }

    [Table("Midias")]
    public class Midia {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela Filmes")]
        public required string IdFilme { get; set; }

        [ForeignKey("IdFilme")]
        public required Filme? Filme { get; set; }

        [Display(Name = "URL do vídeo (480p)")]
        public string? _480 { get; set; }

        [Display(Name = "URL do vídeo (max)")]
        public string? Max { get; set; }
    }

    [Table("Conquistas")]
    public class Conquista {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Número de pessoas que atingiram essa conquista")]
        public string? Total { get; set; }

        [Display(Name = "Destaques")]
        public ICollection<Destaque>? Highlighted { get; set; }
    }

    [Table("Destaques")]
    public class Destaque {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela Conquistas")]
        public required string IdConquistas { get; set; }

        [ForeignKey("IdConquistas")]
        public required Conquista Conquista { get; set; }

        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Display(Name = "URL")]
        public string? Path { get; set; }
    }

    [Table("DatasDeLancamento")]
    public class DataDeLancamento {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Está chegando?")]
        public bool ComingSoon { get; set; }

        [Display(Name = "Data de lançamento")]
        public string? Date { get; set; }
    }

    [Table("InformacoesDeSuporte")]
    public class InformacaoDeSuporte {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "URL")]
        public string? Url { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }
    }

    [Table("DescritoresDeConteudo")]
    public class DescritorDeConteudo {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Ids")]
        public ICollection<string>? Ids { get; set; }

        [Display(Name = "Notas")]
        public string? Notes { get; set; }
    }

    [Table("Classificacoes")]
    public class Classificacao {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Classificação DEJUS")]
        public ICollection<ClassificacaoIndicativa>? Dejus { get; set; }

    }

    [Table("ClassificacoesIndicativas")]
    public class ClassificacaoIndicativa {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela Classificações")]
        public required string IdClassificacoes { get; set; }

        [ForeignKey("IdClassificacoes")]
        public required Classificacao? Classificacao { get; set; }

        [Display(Name = "Classificação")]
        public string? Rating { get; set; }

        [Display(Name = "Descrição")]
        public string? Descriptors { get; set; }

        [Display(Name = "Usar barreira de idade?")]
        public string? UseAgeGate { get; set; }

        [Display(Name = "Recomendação etária")]
        public string? RequiredAge { get; set; }
    }

    [Table("Demos")]
    public class Demos {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Id do jogo (referencia na Steam)")]
        public string? Appid { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }
    }
}
