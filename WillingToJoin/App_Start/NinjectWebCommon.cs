using WillingToJoin.Shared.Context;
using WillingToJoin.Shared.Gateways;
using WillingToJoin.Shared.Repositories;
using WillingToJoin.Shared.Services.Messaging;
using Ninject.Modules;

namespace WillingToJoin.App_Start
{
    using AutoMapper;
    using Ninject.Web.Common;

    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<DatabaseContext>().To<DatabaseContext>().InRequestScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            #region Gateways
            Bind<ITwilioGateway>().To<TwilioGateway>();
            Bind<ISendGridGateway>().To<SendGridGateway>();
            #endregion

            #region Services
            Bind<Shared.Services.Accounts.IAccountService>().To<Shared.Services.Accounts.AccountService>();
            Bind<IEmailService>().To<EmailService>();
            Bind<ISmsService>().To<SmsService>();

            Bind<Shared.Services.Contacts.IAccountService>().To<Shared.Services.Contacts.AccountService>();
            Bind<Shared.Services.Contacts.IHouseholdService>().To<Shared.Services.Contacts.HouseholdService>();
            Bind<Shared.Services.Contacts.IContactService>().To<Shared.Services.Contacts.ContactService>();
            Bind<Shared.Services.Contacts.IHouseholdNoteService>().To<Shared.Services.Contacts.HouseholdNoteService>();
            Bind<Shared.Services.Contacts.IDonationService>().To<Shared.Services.Contacts.DonationService>();

            #endregion

            #region Repositories
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            #endregion

            #region Mapper
            Bind(typeof(IMapper)).ToMethod(x=> (new AutoMapperConfig()).Mapper);
            #endregion
        }
    }
}
