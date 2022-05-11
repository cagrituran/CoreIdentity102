using System.ComponentModel.DataAnnotations;

namespace CoreIdentity102.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="{0} alani zorunludur"),Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} alani zorunludur"), Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} alani zorunludur"), Display(Name = "Sifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} alani zorunludur"), Display(Name = "Telefon No")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
