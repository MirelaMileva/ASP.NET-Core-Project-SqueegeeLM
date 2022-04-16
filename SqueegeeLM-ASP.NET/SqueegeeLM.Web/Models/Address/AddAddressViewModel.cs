namespace SqueegeeLM.Web.Models.Address
{
    using System.ComponentModel.DataAnnotations;

    using static WebConstants;
    public class AddAddressViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(AddressCountryMaxLength, MinimumLength = AddressCountryMinLength)]
        public string Country { get; set; }

        [Required]
        [StringLength(AddressCityNameMaxLength, MinimumLength = AddressCityNameMinLength)]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Required]
        [StringLength(AddressPostCodeMaxLength, MinimumLength = AddressPostCodeMinLength)]
        public string PostCode { get; set; }

        [Required]
        [StringLength(AddressStreetMaxLength, MinimumLength = AddressStreetMinLength)]
        public string Street { get; set; }

        [Required]
        [StringLength(AddressBuildingNumberMaxLength, MinimumLength = AddressBuildingNumberMinLength)]
        [Display(Name = "Building Number")]
        public string BuildingNumber { get; set; }

        public int CustomerId { get; set; }
    }
}
