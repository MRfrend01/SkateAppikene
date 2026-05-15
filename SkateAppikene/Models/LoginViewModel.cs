using System.ComponentModel.DataAnnotations;

namespace SkateAppikene.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-posti aadress on kohustuslik")]
        [EmailAddress(ErrorMessage = "Sisesta kehtiv e-posti aadress")]
        [Display(Name = "E-posti aadress")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parool on kohustuslik")]
        [DataType(DataType.Password)]
        [Display(Name = "Parool")]
        public string Parool { get; set; } = string.Empty;

        [Display(Name = "Jäta mind meelde")]
        public bool JataMinutMeelde { get; set; }
    }
}
