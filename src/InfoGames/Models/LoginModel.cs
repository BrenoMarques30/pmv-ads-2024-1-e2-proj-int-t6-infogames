using System.ComponentModel.DataAnnotations;

namespace InfoGames.Models {
    public class LoginModel {
        [Required(ErrorMessage = "Digite o Email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}
