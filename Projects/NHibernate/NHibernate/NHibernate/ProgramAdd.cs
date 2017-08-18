using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Odbc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using HibernatingRhinos.Profiler;

namespace NHibernate
{
    public partial  class Program
    {

        private static void CreateSchema(Cfg.Configuration cfg)
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
    }
}
