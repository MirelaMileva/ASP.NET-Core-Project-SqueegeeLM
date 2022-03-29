using SqueegeeLM.Data.Models.Enums;

namespace SqueegeeLM.Web.Models.Service
{
    public class CleaningCategoryServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CleaningType CleaningType { get; set; }
    }
}
