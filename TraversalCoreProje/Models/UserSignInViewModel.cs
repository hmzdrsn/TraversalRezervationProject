using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Giriniz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifrenizi Giriniz!")]
        public string Password { get; set; }
    }
}
