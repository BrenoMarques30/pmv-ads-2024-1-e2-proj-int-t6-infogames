using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoGames.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("NomeDeUsuario")]
        [Display(Name = "Nome de Usuário")]
        public string NomeDeUsuario { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Column("Token")]
        [Display(Name = "Token")]
        public string Token { get; set; }

        [Column("DataNascimento")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("ContaSuspensa")]
        [Display(Name = "Conta Suspensa")]
        public bool ContaSuspensa { get; set; }

        [Column("ContaRestrita")]
        [Display(Name = "Conta Restrita")]
        public bool ContaRestrita { get; set; }

        [Column("SteamIdVinculado")]
        [Display(Name = "Steam ID Vinculado")]
        public int SteamIdVinculado { get; set; }

        [Column("EmailVerificado")]
        [Display(Name = "Email Verificado")]
        public bool EmailVerificado { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

        public bool AtualizarSenha(string senha)
        {
            try
            {
                Senha = senha;
                return true;
            }
            catch { return false; }
        }
    }
}
