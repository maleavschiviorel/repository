using Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;
using System.Web.Configuration;

namespace Repository.Implementations
{
    public class SessionGenerator
    {
        public  SessionGenerator()
        {
            //CreateConfiguration();
        }


        public static SessionGenerator Instance
        {
            get { return _sessionGenerator; }
        }



        #region Public members

        public ISession GetSession()
        {
            if (constr == null)
            {
                constr = WebConfigurationManager.ConnectionStrings["NHibernate"].ConnectionString;
               // CreateConfiguration();
            }
            return SessionFactory.OpenSession();
        }

        #endregion

        #region Non-public static members

        static private string constr = ConfigurationManager.ConnectionStrings["NHibernate"].ConnectionString;// WebConfigurationManager.ConnectionStrings["NHibernate"].ConnectionString;

        private static readonly SessionGenerator _sessionGenerator = new SessionGenerator();
        private static readonly ISessionFactory SessionFactory = CreateSessionFactory();
       
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure().
                Database(MsSqlConfiguration.MsSql2012.ConnectionString(constr)).
                Mappings(
                    m =>
                    {
                        m.FluentMappings.AddFromAssemblyOf<OrderMap>();
                        // m.FluentMappings.AddFromAssemblyOf<PersonMap>();
                        // m.FluentMappings.AddFromAssemblyOf<ClientMap >();
                    }).
                BuildSessionFactory();
        }

        private static void CreateSchema(NHibernate.Cfg.Configuration cfg)
        {
            var schemaExport = new SchemaExport(cfg);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);

        }

        private static void CreateConfiguration()
        {
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(constr))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<OrderMap>();
                    //m.FluentMappings.AddFromAssemblyOf<PersonMap>();
                    // m.FluentMappings.AddFromAssemblyOf<ClientMap>();
                    // m.FluentMappings.ExportTo(@"D:\localrepo\Projects\NHibernate\NHibernate\NHibernate\bin\Debug");
                    // m.HbmMappings..ExportTo("...file path here...");
                    // m.AutoMappings.ExportTo("d:\\automap.txt");


                }
                ).

                ExposeConfiguration(CreateSchema).
                BuildConfiguration();
        }
        #endregion
    }
}
