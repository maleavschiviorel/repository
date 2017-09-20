using System;
using System.IO;
using System.Linq;
using NHibernate.AspNet.Identity;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.AspNet.Web.Models;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate;
using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Web.Configuration;

namespace NHibernate.AspNet.Web
{
    public class DataConfig
    {
        public static void Configure(ISessionStorage storage)
        {
            var internalTypes = new[] {
                typeof(ApplicationUser)
            };

       

        var mapping = MappingHelper.GetIdentityMappings(internalTypes);
            //System.Diagnostics.Debug.WriteLine(mapping.AsString());

        string connString =  WebConfigurationManager.ConnectionStrings["NHibernate"].ConnectionString;

            var config = Fluently.Configure()
                .Database(MsSqlConfiguration
                .MsSql2012
                .ConnectionString(connString))
                .Mappings(mappingConfig => mappingConfig.FluentMappings.AddFromAssemblyOf<IdentityUser>())
                .BuildConfiguration();

            NHibernateSession.Init(storage, mapping);


           // var configuration = NHibernateSession.Init(storage, mapping);
           
           // BuildSchema(configuration);
        }

        //private static void DefineBaseClass(ConventionModelMapper mapper, System.Type[] baseEntityToIgnore)
        //{
        //    if (baseEntityToIgnore == null) return;
        //    mapper.IsEntity((type, declared) =>
        //        baseEntityToIgnore.Any(x => x.IsAssignableFrom(type)) &&
        //        !baseEntityToIgnore.Any(x => x == type) &&
        //        !type.IsInterface);
        //    mapper.IsRootEntity((type, declared) => baseEntityToIgnore.Any(x => x == type.BaseType));
        //}

        private static void BuildSchema(Configuration config)
        {
            //var path = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), @"schema.sql");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it

            // serii
            //new SchemaExport(config)
            //    .SetOutputFile(path)
            //    .Create(true, true /* DROP AND CREATE SCHEMA */);

            new SchemaUpdate(config).Execute(false, true);

        }




    }

    
}