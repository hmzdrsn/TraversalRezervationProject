using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{//proje dışı
    public class AppUserEditDTOs
    {
        public string UserName { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        [Required(ErrorMessage ="Boş Bırakılamaz")]
        public string password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar Alanı Boş Bırakılamaz")]
        public string confirmpassword { get; set; }
        public string phonenumber { get; set; }
        public string mail { get; set; }
        public string imageurl { get; set; }
        public IFormFile Image { get; set; }
    }
}
