namespace SqueegeeLM.Web.Extensions
{
    using AutoMapper;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Models.Appoitment;
    using SqueegeeLM.Services.Models.Appoitments;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Service, ServiceListServiceModel>()
                .ForMember(s => s.CleaningCategory, cfg => cfg.MapFrom(s => s.CleaningCategory.Name))
                .ForMember(s => s.PropertyCategory, cfg => cfg.MapFrom(s => s.PropertyCategory.Name))
                .ForMember(s => s.Frequency, cfg => cfg.MapFrom(s => s.Frequency.Name));
            ;

            this.CreateMap<Appoitment, AppoitmentServiceModel>();

            this.CreateMap<Appoitment, AppoitmentServiceModel>()
                .ForMember(a => a.Services, cfg => cfg.MapFrom(s => s.Services));

            this.CreateMap<Service, ServiceListServiceModel>();

        }
    }
}
