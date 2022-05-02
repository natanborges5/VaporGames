using System.ComponentModel.DataAnnotations;

namespace VaporGames.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Inform your name")]
        [StringLength(50, ErrorMessage = "Your name is too big")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Inform your last name")]
        [StringLength(50, ErrorMessage = "Your last name is too big")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Inform your Address")]
        [StringLength(100, ErrorMessage = "Your address name is too big")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Inform your Address 2")]
        [StringLength(100, ErrorMessage = "Your Address name is too big")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Inform your Postal code")]
        [Display(Name ="Postal code")]
        [StringLength(10,MinimumLength =8, ErrorMessage = "Your Address name is too big")]
        public string PostalCode { get; set; }
        [StringLength(25)]
        public string State { get; set; }
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Inform your Phone")]
        [StringLength(25, ErrorMessage = "Your Phone number is too big")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Inform your Email")]
        [StringLength(50, ErrorMessage = "Your Email name is too big")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        public float TotalValue { get; set; }
        public int TotalItensOrder { get; set; }

        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy hh:mm}")]
        public DateTime OrderDate { get; set; }

        public List<OrderDetails> OrderItens { get; set; }
    }
}
