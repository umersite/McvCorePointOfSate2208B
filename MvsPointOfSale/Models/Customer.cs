using System.ComponentModel.DataAnnotations;

namespace MvsPointOfSale.Models
{
    public class Customer
    {
        [Key]
        public System.Guid CustomerId { get; set; }

        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="Customer Name is required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public virtual ICollection<Order> Orders { get;}


    }
}
