namespace Factory.IoC
{
   using ActionImplementations;
   using Castle.MicroKernel;
   using Castle.MicroKernel.Registration;
   using InterfaceActions.Actions;
   using Repository.Implementations;
   using Repository.Interfaces;

   internal static class ServiceLocator
   {
      #region Public static members

      public static void RegisterAll(IKernel kernel)
      {
         _kernel = kernel;
         _kernel.Register(
            Component.For(typeof (INotifyUsersAction))
                     .ImplementedBy(typeof (SmsNotification)));
         _kernel.Register(
            Component.For(typeof (IProductRepository))
                     .ImplementedBy(typeof (ProductRepository)));
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