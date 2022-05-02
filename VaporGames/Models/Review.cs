namespace VaporGames.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Boolean Recomended { get; set; }
        public string Date { get; set; }
        public Game Game { get; set; }
    }
}
