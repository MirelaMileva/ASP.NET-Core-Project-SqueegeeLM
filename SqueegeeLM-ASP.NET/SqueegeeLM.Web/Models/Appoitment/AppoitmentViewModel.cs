namespace SqueegeeLM.Web.Models.Appoitment
{
    using SqueegeeLM.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class AppoitmentViewModel
    {
        public string Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<ServiceListViewModel> Services { get; set; }
    }
}
