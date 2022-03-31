namespace SqueegeeLM.Web.Models.Customer
{
    using System.ComponentModel.DataAnnotations;

    public class BecomeCustomerViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}