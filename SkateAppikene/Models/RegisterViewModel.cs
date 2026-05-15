using System.ComponentModel.DataAnnotations;

namespace SkateAppikene.Models
{
    public class RegisterViewModel
    {
        [Required] public string Eesnimi { get; set; }
        [Required] public string Perenimi { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [Required] public string Kasutajanimi { get; set; }
        [Required, MinLength(6)] public string Parool { get; set; }
        [Compare("Parool")] public string ParoolKinnitus { get; set; }
        public string Tase { get; set; }
    }
    }
