using System.ComponentModel.DataAnnotations;

namespace VaporGames.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="The name of the game must be provided")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public float Price { get; set; }
        public int MetaCritic { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumb { get; set; }
        public string ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }


    }
}
