using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


namespace TraversalCoreProje.Models
{
	public class UserRegisterViewModel
	{
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Adınızı Giriniz")]
		public string Name { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Soyadınızı Giriniz")]
		public string Surname { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Kullanıcı Adınızı Giriniz")]
		public string Username { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Mail Adresinizi Giriniz")]
		public string Mail { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Şifrenizi Giriniz")]
		public string Password { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Şifrenizi Tekrar Giriniz")]

		[Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor!")]
		public string ConfirmPassword { get; set; }

	}
}
