using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SMStore.Entities
{
    public class AppUser :IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Adı"),Required(ErrorMessage ="{0} Alanı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        public string Surname { get; set; }

        [Display(Name = "Email"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!"),EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public int? Phone { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }
        [Display(Name = "Şifre"), Required(ErrorMessage = "{0} Alanı Boş Geçilemez!")]
        public string Password { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Ekleme Tarihi"),ScaffoldColumn(false)] // scaffoldCloumn(false) attiribute ü bu alanın otomatik oluşan   crud sayfalarına satır olarak eklenmesini sağlar
        public DateTime? CreateDate { get; set; } = DateTime.Now;



    }
}
