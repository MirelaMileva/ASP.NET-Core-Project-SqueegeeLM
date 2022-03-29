namespace SqueegeeLM.Web.Models.Service
{
    using SqueegeeLM.Data.Models.Enums;

    public class CleaningCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CleaningType CleaningTypes { get; set; }
    }
}
