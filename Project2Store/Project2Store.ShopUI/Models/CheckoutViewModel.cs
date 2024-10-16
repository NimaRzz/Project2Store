using System.ComponentModel.DataAnnotations;

namespace Project2Store.ShopUI.Models
{
    public class CheckoutViewModel
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
