namespace SkateAppikene.Models
{
    public class Pin
    {
        public int Id { get; set; }

        public string Nimi { get; set; } = "";

        public string Tase { get; set; } = "";

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}