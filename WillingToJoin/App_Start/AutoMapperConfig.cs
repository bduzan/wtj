using AutoMapper;
using WillingToJoin.Areas.CRM.Models;
using WillingToJoin.Shared.Data;
using WillingToJoin.Shared.Domain;

namespace WillingToJoin.App_Start
{
    public class AutoMapperConfig
    {
        private readonly IMapper _mapper;

        public IMapper Mapper
        {
            get { return _mapper; }
        }

        public AutoMapperConfig()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                ConfigureMappings(cfg);
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            _mapper = mapper;
        }

        private void ConfigureMappings(IProfileExpression cfg)
        {
            cfg.CreateMap<Account, AccountViewModel>().ReverseMap();
            cfg.CreateMap<Contact, ContactViewModel>().ReverseMap();
            cfg.CreateMap<Household, HouseholdViewModel>().ReverseMap();
            cfg.CreateMap<Household, WillingToJoin.Areas.CRM2.Models.HouseholdsViewModel>().ReverseMap();
            cfg.CreateMap<Household, WillingToJoin.Areas.CRM2.Models.HouseholdsDetailsViewModel>().ReverseMap();
            cfg.CreateMap<HouseholdNote, WillingToJoin.Areas.CRM2.Models.HouseholdsNotesViewModel>().ReverseMap();
            cfg.CreateMap<Contact, WillingToJoin.Areas.CRM2.Models.ContactsViewModel>().ReverseMap();
            cfg.CreateMap<Transaction, WillingToJoin.Areas.CRM2.Models.DonationsViewModel>().ReverseMap();
        }

    }
}