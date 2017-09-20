using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace NHibernate.AspNet.Web.Models
{
    public class NhibernateProvider
    {
        //private const string connString = @"Server=.;Database=UserDB;Trusted_Connection=True";
        
        //private static ISessionFactory _sessionFactory;

        //public static ISession GetSession()
        //{
        //    if (_sessionFactory == null)
        //    {
        //        _sessionFactory = CreateSessionFactory();
        //    }
        //    return _sessionFactory.OpenSession();
        //}
        //private static ISessionFactory CreateSessionFactory()
        //{

        //    return Fluently.Configure()
        //        .Database(MsSqlConfiguration
        //            .MsSql2012
        //            .ConnectionString(connString))
        //        .Mappings(m => m.FluentMappings
        //            .AddFromAssemblyOf<Product>())
        //        //.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
        //        .BuildSessionFactory();
        //}
    }
}