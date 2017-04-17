using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Entity.Models.ViewModel
{
    public class RegisterModel
    {
        [Display(Name = "İsim")]
        [StringLength(35, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string Name { get; set; }

        [Display(Name = "Soyisim")]
        [StringLength(35, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string Surname { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        [StringLength(15, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 10)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail adresi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(30, ErrorMessage = "{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string Address { get; set; }

    }
}
