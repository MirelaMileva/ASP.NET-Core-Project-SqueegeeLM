﻿namespace SqueegeeLM.Web.Models.Appoitment
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceListViewModel
    {
        [Display(Name = "Cleaning Category")]
        public int CleaningCategoryId { get; set; }
        public string CleaningCategories { get; set; }

        [Display(Name = "Property")]
        public int PropertyCategoryId { get; set; }

        public string PropertyCategories { get; set; }

        [Display(Name = "Frequency")]
        public int FrequencyId { get; set; }

        public string Frequency { get; set; }
    }
}
