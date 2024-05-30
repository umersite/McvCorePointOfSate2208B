using System.ComponentModel.DataAnnotations;

namespace MvsPointOfSale.Models
{
    public class Order
    {

        [Key]
        public System.Guid OrderID { get; set; }
        [Required(ErrorMessage ="Product Name is required")]
        [Display(Name ="Product Name")]
        public String ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public System.Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
