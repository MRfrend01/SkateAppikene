namespace SkateAppikene.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string ParkName { get; set; }

        public string Kasutajanimi { get; set; }

        public int Score { get; set; } 

        public string Comment { get; set; }

        public string ParkImage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}