namespace Factory
{
   using System;
   using System.Collections.Generic;
   using Domain.Domain;
   using Domain.DomainUtils;
   using Domain.Dto;
   using Factories.Factory;
   using HibernatingRhinos.Profiler.Appender.NHibernate;
   using IoC;
   using Repository.Interfaces;

   public class Client
   {
      #region Public static members

      public static void Main()
      {
         SaveProducts(5);
         Console.ReadKey();
      }

      public static void SaveProducts(int number)
      {
         var repository = ServiceLocator.Get<IProductRepository>();
         var product = repository.GetProductDetails(new PageData
         {
            Page = 2, PageSize = 5,
            SortAsc = true, SortBy = "Name"
         });
        
         repository.FindMostPopularProductInCategory(1l);
      }

      #endregion

      #region Non-public static members

      private static ProductFactory ProductFactory;

      static Client()
      {
         NHibernateProfiler.Initialize();
         ServiceLocator.RegisterAll();
         ProductFactory = ServiceLocator.Get<ProductFactory>();
      }

      #endregion
   }
}