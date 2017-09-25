using System.ComponentModel;
using Domain.Domain;
using AutoMapper;


namespace Factory.IoC
{
    using BLL;
    using BLL.DTO;
    using BLL.Interfaces;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using NHibernate;
    using Repository.Implementations;
    using Repository.Interfaces;

    public static class ServiceLocator
    {
        #region Public static members

        public static void RegisterAll(IKernel kernel)
        {
            _kernel = kernel;

            _kernel.Register(
                  Component.For<ISessionFactory>()
                .LifeStyle.Singleton
                .UsingFactoryMethod(SessionGenerator.CreateSessionFactory),
            Component.For<ISession>()
                .LifeStyle.PerWebRequest
                .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()),
                Component.For(typeof(IRepository<Entity>))
                    .ImplementedBy(typeof(GenericRepository<Entity>)).LifeStyle.Transient,
                Component.For(typeof(ILogicService<OrderDto>))
                    .ImplementedBy(typeof(LogicOrderService)).LifeStyle.Transient,
                Component.For(typeof(ILogicService<ClientDto>))
                    .ImplementedBy(typeof(LogicClientService)).LifeStyle.Transient
                    );
        }

        public static T Get<T>()
        {
            return _kernel.Resolve<T>();
        }

        #endregion

        #region Non-public static members

        private static IKernel _kernel;

        #endregion

    }
}