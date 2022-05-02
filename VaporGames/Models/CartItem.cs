using System.ComponentModel.DataAnnotations;

namespace VaporGames.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Game Game { get; set; }

        [StringLength(200)]
        public string CartId { get; set; }
    } 
}
