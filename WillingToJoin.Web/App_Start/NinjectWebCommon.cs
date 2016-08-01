
namespace WillingToJoin.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Modules;
    using WillingToJoin.Shared.Gateways;
    using WillingToJoin.Shared.Services.Messaging;
    using WillingToJoin.Shared.Context;
    using WillingToJoin.Shared.Repositories;
    using Umbraco.Core.Persistence;

    public class NinjectWebCommon : NinjectModule
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
            #endregion

            #region Repositories
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            #endregion
        }
    }
}
