namespace SqueegeeLM.Web.Models.Customer
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class BecomeCustomerViewModel
    {
        [Required]
        [StringLength(CustomerFirstNameMaxLength, MinimumLength = CustomerFirstNameMinLength)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(CustomerLastNameMaxLength, MinimumLength = CustomerLastNameMinLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [StringLength(CustomerPhoneNumberMaxLength, MinimumLength = CustomerPhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}