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
        public string? Tipo { get; set; }

        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Display(Name = "Id do Jogo (referencia na Steam)")]
        public string? AppId { get; set; }

        [Display(Name = "Recomendação etária")]
        public string? RecomendacaoEtaria { get; set; }

        [Display(Name = "É gratuito")]
        public bool? EGratuito { get; set; }

        [Display(Name = "Suporte à Controle")]
        public string? SuporteAControle { get; set; }

        [Display(Name = "Descrição detalhada")]
        public string? DescricaoDetalhada { get; set; }

        [Display(Name = "Sobre o jogo")]
        public string? SobreOJogo { get; set; }

        [Display(Name = "Descrição curta")]
        public string? DescricaoCurta { get; set; }

        [Display(Name = "Línguas disponíveis")]
        public string? LinguasDisponiveis { get; set; }

        [Display(Name = "Imagem Principal")]
        public string? ImagemPrincipal { get; set; }

        [Display(Name = "Thumbnail")]
        public string? Thumbnail { get; set; }

        [Display(Name = "Thumbnailv5")]
        public string? Thumbnailv5 { get; set; }

        [Display(Name = "Website")]
        public string? Website { get; set; }

        [Display(Name = "Notificação Legal")]
        public string? NotificacaoLegal { get; set; }

        [Display(Name = "Número de Likes")]
        public string? NumeroDeLikes { get; set; }

        [Display(Name = "Imagem de fundo")]
        public string? ImagemBackground { get; set; }

        [Display(Name = "Imagem de fundo, sem tratamento")]
        public string? ImagemBackgroundRaw { get; set; }

        [Display(Name = "DLCs")]
        public List<string>? Dlc { get; set; }

        [Display(Name = "Desenvolvedores")]
        public List<string>? Desenvolvedor { get; set; }

        [Display(Name = "Editores")]
        public List<string>? Editor { get; set; }

        [Display(Name = "Pacotes")]
        public List<string>? Pacotes { get; set; }

        [Display(Name = "Jogo Completo")]
        public JogoCompleto? JogoCompleto { get; set; }

        [Display(Name = "Requisitos de Hardware para Windows")]
        public RequisitoPC? RequisitoPC { get; set; }

        [Display(Name = "Requisitos de Hardware para Mac")]
        public RequisitoMac? RequisitoMac { get; set; }

        [Display(Name = "Requisitos de Hardware para Linux")]
        public RequisitoLinux? RequisitoLinux { get; set; }

        [Display(Name = "Detalhes dos preços")]
        public DetalhesDoPreco? DetalhesDoPreco { get; set; }

        [Display(Name = "Grupos de pacotes")]
        public ICollection<GrupoDePacote>? GrupoDePacotes { get; set; }

        [Display(Name = "Plataformas")]
        public Plataforma? Plataforma { get; set; }

        [Display(Name = "Metacrítica")]
        public Metacritica? Metacritica { get; set; }

        [Display(Name = "Categorias")]
        public ICollection<Categoria>? Categoria { get; set; }

        [Display(Name = "Generos")]
        public ICollection<Generos>? Genero { get; set; }

        [Display(Name = "Fotos")]
        public ICollection<Screenshot>? Screenshot { get; set; }

        [Display(Name = "Filmes")]
        public ICollection<Filme>? Filme { get; set; }

        [Display(Name = "Conquista")]
        public Conquista? Conquista { get; set; }

        [Display(Name = "Data de lançamento")]
        public DataDeLancamento? DataDeLancamento { get; set; }

        [Display(Name = "Informações de suporte")]
        public InformacaoDeSuporte? InformacaoDeSuporte { get; set; }

        [Display(Name = "Descritores de conteúdo")]
        public DescritorDeConteudo? DescritorDeConteudo { get; set; }

        [Display(Name = "Classificações")]
        public Classificacao? Classificacao { get; set; }

        [Display(Name = "Demonstrações")]
        public ICollection<Demos>? Demonstracao { get; set; }
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
        public required string IdJogoCompleto { get; set; }

        [Display(Name = "Nome do jogo completo")]
        public required string Nome { get; set; }
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
        public string? Minimo { get; set; }

        [Display(Name = "Requisitos Recomendados")]
        public string? Recomendado { get; set; }
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
        public string? Minimo { get; set; }

        [Display(Name = "Requisitos Recomendados")]
        public string? Recomendado { get; set; }
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
        public string? Minimo { get; set; }

        [Display(Name = "Requisitos Recomendados")]
        public string? Recomendado { get; set; }
    }

    [Table("DetalhesDosPrecos")]
    public class DetalhesDoPreco {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Moeda")]
        public string? Moeda { get; set; }

        [Display(Name = "Preço Inicial")]
        public string? PrecoInicial { get; set; }

        [Display(Name = "Preço Final")]
        public string? PrecoFinal { get; set; }

        [Display(Name = "Desconto (%)")]
        public string? DescontoPorcentagem { get; set; }

        [Display(Name = "Preço Inicial Formatado")]
        public string? PrecoInicialFormatado { get; set; }

        [Display(Name = "Preço Final Formatado")]
        public string? PrecoFinalFormatado { get; set; }
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
        public string? Nome { get; set; }

        [Display(Name = "Título")]
        public string? Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Display(Name = "Seleção de texto")]
        public string? SelecaoDeTexto { get; set; }

        [Display(Name = "Salvar texto")]
        public string? SalvarTexto { get; set; }

        [Display(Name = "Exibir tipo")]
        public string? ExibirTipo { get; set; }

        [Display(Name = "É assinatura recorrente")]
        public string? EAssinaturaRecorrente { get; set; }

        [Display(Name = "Pacotes")]
        public ICollection<Pacote>? Pacotes { get; set; }
    }

    [Table("Pacotes")]
    public class Pacote {
        [Key] public required string IdGrupoDePacote { get; set; }

        [ForeignKey("GrupoDePacoteId")]
        public required GrupoDePacote? GrupoDePacote { get; set; }

        [Display(Name = "Id do pacote (referencia na Steam)")]
        public string? PackageId { get; set; }

        [Display(Name = "Porcentagem do desconto (texto)")]
        public string? PorcentagemDoDescontoTexto { get; set; }

        [Display(Name = "Porcentagem do desconto")]
        public string? PorcentagemDoDesconto { get; set; }

        [Display(Name = "Opção (texto)")]
        public string? OpcaoTexto { get; set; }

        [Display(Name = "Opção (descrição)")]
        public string? OpcaoDescricao { get; set; }

        [Display(Name = "Licensa pode ser obtida gratuitamente?")]
        public string? ObtidaGratuitamente { get; set; }

        [Display(Name = "Licensa é gratuita?")]
        public bool? LicencaEGratuita { get; set; }

        [Display(Name = "Preço com desconto (em centavos)")]
        public string? PrecoComDesconto { get; set; }
    }

    [Table("Plataformas")]
    public class Plataforma {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Windows")]
        public bool? Windows { get; set; }

        [Display(Name = "macOS")]
        public bool? Mac { get; set; }

        [Display(Name = "Linux")]
        public bool? Linux { get; set; }
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
        public string? Pontuacao { get; set; }

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
        public string? Descricao { get; set; }
    }

    [Table("Generos")]
    public class Generos {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public required string IdDetalhesJogo { get; set; }

        [ForeignKey("IdDetalhesJogo")]
        public required DetalhesJogo? DetalhesJogo { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Display(Name = "Id do Gênero (referencia na Steam)")]
        public string? IdGenero { get; set; }
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
        public required string UrlThumbnail { get; set; }

        [Display(Name = "URL da imagem completa")]
        public required string UrlImagemCompleta { get; set; }
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
        public string? Nome { get; set; }

        [Display(Name = "URL da thumbnail")]
        public string? Thumbnail { get; set; }

        [Display(Name = "Vídeo (Web movie)")]
        public Webm? Webm { get; set; }

        [Display(Name = "Vídeo (.mp4)")]
        public Mp4? Mp4 { get; set; }

        [Display(Name = "Destacar?")]
        public bool Destacar { get; set; }
    }

    [Table("Webms")]
    public class Webm {
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

    [Table("Mp4s")]
    public class Mp4 {
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
        public ICollection<Destaque>? Destaque { get; set; }
    }

    [Table("Destaques")]
    public class Destaque {
        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [Display(Name = "Id da key na tabela Conquistas")]
        public required string IdConquista { get; set; }

        [ForeignKey("IdConquistas")]
        public required Conquista Conquista { get; set; }

        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Display(Name = "URL")]
        public string? UrlIcone { get; set; }
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
        public bool EstaChegando { get; set; }

        [Display(Name = "Data de lançamento")]
        public string? Data { get; set; }
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
        public string? Notas { get; set; }
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
        public ClassificacaoIndicativa? Dejus { get; set; }

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
        public string? Descricao { get; set; }

        [Display(Name = "Usar barreira de idade?")]
        public string? BloquearPorIdade { get; set; }

        [Display(Name = "Recomendação etária")]
        public string? RecomendacaoEtaria { get; set; }
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
        public string? Descricao { get; set; }
    }
}
