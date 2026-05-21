namespace SkateAppikene.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Eesnimi { get; set; } = string.Empty;
        public string Perenimi { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Kasutajanimi { get; set; } = string.Empty;
        public string ParoolHash { get; set; } = string.Empty;
        public string Tase { get; set; } = string.Empty;
        public DateTime LoodudKuupäev { get; set; } = DateTime.Now;
    }
}