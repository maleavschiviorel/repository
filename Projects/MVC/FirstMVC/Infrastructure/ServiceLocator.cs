using System.ComponentModel;
using Domain.Domain;

namespace Factory.IoC
{
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Repository.Implementations;
    using Repository.Interfaces;

    public static class ServiceLocator
    {
        #region Public static members

        public static void RegisterAll(IKernel kernel)
        {
            _kernel = kernel;
        
            _kernel.Register(
                Component.For(typeof(IRepository<Entity>))
                    .ImplementedBy(typeof(GenericRepository<Entity>)));
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