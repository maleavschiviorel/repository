﻿namespace Infrastructure
{
   using Domain.Mapping;
   using FluentNHibernate.Cfg;
   using FluentNHibernate.Cfg.Db;
   using NHibernate;
   using NHibernate.Tool.hbm2ddl;

   public class SessionGenerator
   {
      #region Public static members

      public static SessionGenerator Instance
      {
         get { return _sessionGenerator; }
      }

      #endregion

      #region Public members

      public ISession GetSession()
      {
         return SessionFactory.OpenSession();
      }

      #endregion

      #region Non-public static members

      private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();
      private static readonly ISessionFactory SessionFactory = CreateSessionFactory();

      private static ISessionFactory CreateSessionFactory()
      {
         FluentConfiguration configuration =
            Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                                                .ConnectionString(
                                                   builder =>
                                                      builder.Database(
                                                         "MappingDemo")
                                                             .Server(
                                                                @".")
                                                             .TrustedConnection()))
                .Mappings(cfg => CreateMappings(cfg))
                    .ExposeConfiguration(
                       cfg => new SchemaUpdate(cfg).Execute(false, true));


         return configuration.BuildSessionFactory();
      }

      private static void CreateMappings(MappingConfiguration mappingConfiguration)
      {
         var assembly = typeof(ProductMap).Assembly;

         mappingConfiguration.FluentMappings.AddFromAssembly(assembly);
         mappingConfiguration.HbmMappings.AddFromAssembly(assembly);
      }

      #endregion

      #region Non-public members

      private SessionGenerator()
      {
      }

      #endregion
   }
}