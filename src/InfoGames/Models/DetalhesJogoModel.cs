using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InfoGames.Models.Steam;
using System.Diagnostics.CodeAnalysis;
using Humanizer.Localisation;

namespace InfoGames.Models {
    [Table("DetalhesJogos")]
    public class DetalhesJogoModel {

        public DetalhesJogoModel() { }

        [SetsRequiredMembers]
        public DetalhesJogoModel(AppData _AppData, JogoModel _jogo) {
            Id = Guid.NewGuid().ToString();
            IdJogo = _jogo.Id.ToString();
            Jogo = _jogo;
            Tipo = _AppData?.Type;
            Nome = _AppData?.Name;
            AppId = _AppData?.Appid;
            Pacotes = _AppData?.Packages;
            EGratuito = _AppData?.IsFree;
            SuporteAControle = _AppData?.ControllerSupport;
            DescricaoDetalhada = _AppData?.DetailedDescription;
            SobreOJogo = _AppData?.AboutTheGame;
            DescricaoCurta = _AppData?.ShortDescription;
            LinguasDisponiveis = _AppData?.SupportedLanguages;
            ImagemPrincipal = _AppData?.HeaderImage;
            Thumbnail = _AppData?.CapsuleImage;
            Thumbnailv5 = _AppData?.CapsuleImagev5;
            Website = _AppData?.Website;
            TermosDeUso = _AppData?.LegalNotice;
            NumeroDeLikes = _AppData?.Recommendations?.Total;
            Dlc = _AppData?.Dlc;
            Desenvolvedor = _AppData?.Developers;
            Editor = _AppData?.Publishers;
            Pacotes = _AppData?.Packages;
            RecomendacaoEtaria = _AppData?.RequiredAge;
        }

        [Display(Name = "Id (referencia interna")]
        [Key] public required string Id { get; set; }

        [Display(Name = "Id do Jogo (referencia na Steam)")]
        public required string IdJogo { get; set; }

        [ForeignKey("IdJogo")]
        [Required(ErrorMessage = "Obrigatório informar o _jogo")]
        public required JogoModel Jogo { get; set; }

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

        [Display(Name = "Sobre o _jogo")]
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
        public string? TermosDeUso { get; set; }

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

        [Display(Name = "ClassificaçoesIndicativas")]
        public ClassificacaoIndicativa? Classificacao { get; set; }

        [Display(Name = "Demonstrações")]
        public ICollection<Demonstracoes>? Demonstracao { get; set; }
    }

    public class FilhoDetalheJogo {

        [Key]
        [Display(Name = "Id (referencia interna)")]
        public required string Id { get; set; }

        [ForeignKey("DetalhesJogo")]
        [Display(Name = "Id da key na tabela DetalhesJogos")]
        public string? IdDetalhesJogo { get; set; }

        public DetalhesJogoModel? DetalhesJogo { get; set; }
    }

    [Table("Categorias")]
    public class Categoria : FilhoDetalheJogo {
        public Categoria() { }

        [SetsRequiredMembers]
        public Categoria(Category _Category, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            IdCategoria = _Category.Id;
            Descricao = _Category.Description;
        }

        [Display(Name = "Id da Categoria (referencia na Steam)")]
        public string? IdCategoria { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
    }

    public class Requisito : FilhoDetalheJogo {

        public Requisito() { }

        [SetsRequiredMembers]
        public Requisito(Requirements requirements, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Minimo = requirements.Minimum;
            Recomendado = requirements.Recommended;
        }

        [Display(Name = "Requisitos Mínimos")]
        public string? Minimo { get; set; }

        [Display(Name = "Requisitos Recomendados")]
        public string? Recomendado { get; set; }
    }

    [Table("RequisitosPC")]
    public class RequisitoPC : Requisito {

        public RequisitoPC() { }

        [SetsRequiredMembers]
        public RequisitoPC(Requirements _Requirements, DetalhesJogoModel _DetalhesJogo) : base(_Requirements, _DetalhesJogo) { }
    }

    [Table("RequisitosMac")]
    public class RequisitoMac : Requisito {

        public RequisitoMac() { }

        [SetsRequiredMembers]
        public RequisitoMac(Requirements _Requirements, DetalhesJogoModel _DetalhesJogo) : base(_Requirements, _DetalhesJogo) { }
    }

    [Table("RequisitosLinux")]
    public class RequisitoLinux : Requisito {
        public RequisitoLinux() { }

        [SetsRequiredMembers]
        public RequisitoLinux(Requirements _Requirements, DetalhesJogoModel _DetalhesJogo) : base(_Requirements, _DetalhesJogo) { }
    }

    [Table("JogosCompletos")]
    public class JogoCompleto : FilhoDetalheJogo {
        public JogoCompleto() { }

        [SetsRequiredMembers]
        public JogoCompleto(FullGame fullGame, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            DetalhesJogo = _DetalhesJogo;
            IdJogoCompleto = fullGame.Appid ?? string.Empty;
            Nome = fullGame.Name ?? string.Empty;
        }

        [Display(Name = "Id do _jogo completo (referencia na Steam)")]
        public required string IdJogoCompleto { get; set; }

        [Display(Name = "Nome do _jogo completo")]
        public required string Nome { get; set; }
    }

    [Table("DetalhesDosPrecos")]
    public class DetalhesDoPreco : FilhoDetalheJogo {
        public DetalhesDoPreco() { }

        [SetsRequiredMembers]
        public DetalhesDoPreco(PriceOverview _PriceOverview, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Moeda = _PriceOverview.Currency;
            PrecoInicial = _PriceOverview.Initial;
            PrecoFinal = _PriceOverview.Final;
            DescontoPorcentagem = _PriceOverview.DiscountPercent;
            PrecoInicialFormatado = _PriceOverview.InitialFormatted;
            PrecoFinalFormatado = _PriceOverview.FinalFormatted;

        }

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
    public class GrupoDePacote : FilhoDetalheJogo {
        public GrupoDePacote() { }

        [SetsRequiredMembers]
        public GrupoDePacote(PackageGroup _PackageGroup, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Nome = _PackageGroup?.Name;
            Titulo = _PackageGroup?.Title;
            Descricao = _PackageGroup?.Description;
            SelecaoDeTexto = _PackageGroup?.SelectionText;
            SalvarTexto = _PackageGroup?.SaveText;
            ExibirTipo = _PackageGroup?.DisplayType;
            EAssinaturaRecorrente = _PackageGroup?.IsRecurringSubscription;
        }

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
        public Pacote() { }

        [SetsRequiredMembers]
        public Pacote(Sub sub, GrupoDePacote _GrupoDePacote) {
            Id = Guid.NewGuid().ToString();
            IdGrupoDePacote = _GrupoDePacote.Id;
            GrupoDePacote = _GrupoDePacote;
            PacoteId = sub?.Packageid;
            PorcentagemDoDescontoTexto = sub?.PercentSavingsText;
            PorcentagemDoDesconto = sub?.PercentSavings;
            OpcaoTexto = sub?.OptionText;
            OpcaoDescricao = sub?.OptionDescription;
            ObtidaGratuitamente = sub?.CanGetFreeLicense;
            LicencaEGratuita = sub?.IsFreeLicense;
            PrecoComDesconto = sub?.PriceInCentsWithDiscount;
        }
        [Key]
        public required string Id { get; set; }
        public required string IdGrupoDePacote { get; set; }

        [ForeignKey("GrupoDePacoteId")]
        public required GrupoDePacote? GrupoDePacote { get; set; }

        [Display(Name = "Id do pacote (referencia na Steam)")]
        public string? PacoteId { get; set; }

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
    public class Plataforma : FilhoDetalheJogo {
        public Plataforma() { }

        [SetsRequiredMembers]
        public Plataforma(Platforms _Platforms, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Windows = _Platforms.Windows;
            Mac = _Platforms.Mac;
            Linux = _Platforms.Linux;
        }

        [Display(Name = "Windows")]
        public bool? Windows { get; set; }

        [Display(Name = "macOS")]
        public bool? Mac { get; set; }

        [Display(Name = "Linux")]
        public bool? Linux { get; set; }
    }

    [Table("Metacriticas")]
    public class Metacritica : FilhoDetalheJogo {
        public Metacritica() { }

        [SetsRequiredMembers]
        public Metacritica(Metacritic _Metacritic, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Pontuacao = _Metacritic.Score;
            Url = _Metacritic.Url;
        }

        [Display(Name = "Pontuação")]
        public string? Pontuacao { get; set; }

        [Display(Name = "Link")]
        public string? Url { get; set; }
    }



    [Table("Generos")]
    public class Generos : FilhoDetalheJogo {
        public Generos() { }

        [SetsRequiredMembers]
        public Generos(Genre _Genre, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            IdGenero = _Genre.Id;
            Descricao = _Genre.Description;
        }

        [Display(Name = "Id do Gênero (referencia na Steam)")]
        public string? IdGenero { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
    }

    [Table("Screenshots")]
    public class Screenshot : FilhoDetalheJogo {
        public Screenshot() { }

        [SetsRequiredMembers]
        public Screenshot(Images _Image, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            UrlThumbnail = _Image.PathThumbnail;
            UrlImagemCompleta = _Image.PathFull;
        }

        [Display(Name = "URL da thumbnail")]
        public required string UrlThumbnail { get; set; }

        [Display(Name = "URL da imagem completa")]
        public required string UrlImagemCompleta { get; set; }
    }

    [Table("Filmes")]
    public class Filme : FilhoDetalheJogo {
        public Filme() { }

        [SetsRequiredMembers]
        public Filme(Movie _Movie, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Nome = _Movie.Name;
            Thumbnail = _Movie.Thumbnail;
            Destacar = _Movie.Highlight;
        }

        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Display(Name = "URL da thumbnail")]
        public string? Thumbnail { get; set; }

        [Display(Name = "Destacar?")]
        public bool Destacar { get; set; }

        [Display(Name = "Vídeo (Web movie)")]
        public Webm? Webm { get; set; }

        [Display(Name = "Vídeo (.mp4)")]
        public Mp4? Mp4 { get; set; }
    }

    public class Midias {
        public Midias() { }

        [SetsRequiredMembers]
        public Midias(Media _Media, Filme _Filme) {
            Id = Guid.NewGuid().ToString();
            IdFilme = _Filme.Id;
            Filme = _Filme;
            Max = _Media.Max;
            _480 = _Media._480;
        }

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

    [Table("Webms")]
    public class Webm : Midias {
        public Webm() { }

        [SetsRequiredMembers]
        public Webm(Media _Media, Filme _Filme) : base(_Media, _Filme) { }
    }

    [Table("Mp4s")]
    public class Mp4 : Midias {
        public Mp4() { }

        [SetsRequiredMembers]
        public Mp4(Media _Media, Filme _Filme) : base(_Media, _Filme) { }
    }

    [Table("Conquistas")]
    public class Conquista : FilhoDetalheJogo {
        public Conquista() { }

        [SetsRequiredMembers]
        public Conquista(Achievements _Achievements, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Total = _Achievements.Total;
        }

        [Display(Name = "Número de pessoas que atingiram essa conquista")]
        public string? Total { get; set; }

        [Display(Name = "Destaques")]
        public ICollection<Destaque>? Destaque { get; set; }
    }

    [Table("Destaques")]
    public class Destaque {
        public Destaque() { }

        [SetsRequiredMembers]
        public Destaque(Highlighted _Highlighted, Conquista _Conquista) {
            Id = Guid.NewGuid().ToString();
            IdConquista = _Conquista.Id;
            Conquista = _Conquista;
            Nome = _Highlighted.Name;
            UrlIcone = _Highlighted.Path;
        }

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
    public class DataDeLancamento : FilhoDetalheJogo {
        public DataDeLancamento() { }

        [SetsRequiredMembers]
        public DataDeLancamento(ReleaseDate _ReleaseDate, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Data = _ReleaseDate.Date;
            EstaChegando = _ReleaseDate.ComingSoon;
        }

        [Display(Name = "Está chegando?")]
        public bool EstaChegando { get; set; }

        [Display(Name = "Data de lançamento")]
        public string? Data { get; set; }
    }

    [Table("InformacoesDeSuporte")]
    public class InformacaoDeSuporte : FilhoDetalheJogo {
        public InformacaoDeSuporte() { }

        [SetsRequiredMembers]
        public InformacaoDeSuporte(SupportInfo _SupportInfo, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Url = _SupportInfo.Url;
            Email = _SupportInfo.Email;
        }

        [Display(Name = "URL")]
        public string? Url { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }
    }

    [Table("DescritoresDeConteudo")]
    public class DescritorDeConteudo : FilhoDetalheJogo {
        public DescritorDeConteudo() { }

        [SetsRequiredMembers]
        public DescritorDeConteudo(ContentDescriptors _ContentDescriptors, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Ids = _ContentDescriptors?.Ids;
            Notas = _ContentDescriptors?.Notes;
        }

        [Display(Name = "Ids")]
        public List<string?>? Ids { get; set; }

        [Display(Name = "Notas")]
        public string? Notas { get; set; }
    }

    [Table("ClassificacoesIndicativas")]
    public class ClassificacaoIndicativa : FilhoDetalheJogo {
        public ClassificacaoIndicativa() { }

        [SetsRequiredMembers]
        public ClassificacaoIndicativa(Ratings _Ratings, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Rating = _Ratings.Dejus?.Rating;
            Descricao = _Ratings.Dejus?.Descriptors;
            RecomendacaoEtaria = _Ratings.Dejus?.RequiredAge;
            BloquearPorIdade = _Ratings.Dejus?.UseAgeGate;
        }

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
    public class Demonstracoes : FilhoDetalheJogo {
        public Demonstracoes() { }

        [SetsRequiredMembers]
        public Demonstracoes(Demos _Demos, DetalhesJogoModel _DetalhesJogo) {
            Id = Guid.NewGuid().ToString();
            DetalhesJogo = _DetalhesJogo;
            Appid = _Demos.Appid;
            Descricao = _Demos.Description;
        }

        [Display(Name = "Id do _jogo (referencia na Steam)")]
        public string? Appid { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
    }
}
