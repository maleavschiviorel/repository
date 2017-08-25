using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Odbc;
using System.Runtime.InteropServices;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using HibernatingRhinos.Profiler;
using NHibernate.Criterion;
using NHibernate.Transform;


namespace NHibernate
{
    public class MaterialFirstName
    {
        public string Material { get; set; }
        public string FirstName { get; set; }
    }

    public class FirstNameCl
    {
        public string FirstName { get; set; }
    }

    public class GroupCl
    {
        public int Count { get; set; }
        public string FirstName { get; set; }
        public decimal MaxQuantity { get; set; }
    }

    public partial class Program
    {
        static private string constr = ConfigurationManager.ConnectionStrings["NHibernate"].ConnectionString;


        static void Main(string[] args)
        {
            CreateConfiguration();
            ISessionFactory sf = CreateSessionFactory();
            using (var session = sf.OpenSession())
            {
                Client client = new Client()
                {
                    FirstName = "qqq",
                    LastName = "www",
                    BirthDate = new DateTime(1978, 1, 1),
                    TypeOfClient = "fisic"
                };
                Order order1 = new Order()
                {
                    Material = "material1",
                    Quantity = (decimal)11.1,
                    UnitPrice = 10,
                    Client = client
                };
                Order order2 = new Order()
                {
                    Material = "material2",
                    Quantity = (decimal)22.2,
                    UnitPrice = 20,
                    Client = client
                };
                Client client1 = new Client()
                {
                    FirstName = "rrr",
                    LastName = "jjj",
                    BirthDate = new DateTime(1980, 1, 1),
                    TypeOfClient = "juridic"
                };
                Order order11 = new Order()
                {
                    Material = "material11",
                    Quantity = (decimal)111.1,
                    UnitPrice = 110,
                    Client = client1
                };
                Order order12 = new Order()
                {
                    Material = "material12",
                    Quantity = (decimal)212.2,
                    UnitPrice = 220,
                    Client = client1
                };
                client.Orders = new List<Order>() { order1, order2 };
                client1.Orders = new List<Order>() { order11, order12 };

                using (var tran = session.BeginTransaction())
                {
                    session.SaveOrUpdate(client);
                    session.SaveOrUpdate(client1);
                    session.SaveOrUpdate(order1);
                    session.SaveOrUpdate(order2);

                    tran.Commit();
                }

                using (var tran = session.BeginTransaction())
                {
                    session.SaveOrUpdate(new Client()
                    {
                        FirstName = "iii",
                        LastName = "aaa",
                        BirthDate = new DateTime(1980, 1, 1),
                        TypeOfClient = "fisic"
                    });
                    session.SaveOrUpdate(new Supplier()
                    {
                        FirstName = "FirstN1",
                        LastName = "LastN1",
                        BirthDate = new DateTime(1980, 1, 1),
                        Brend = "zorile"
                    });
                    tran.Commit();
                }


                Order order = null;
                Client cli = null;

                Client client0 = null;
                OrderDe orderde = null;
                var r = session.QueryOver<Person>().List<Person>();

                var r1 = session.QueryOver<Order>().JoinQueryOver(q => q.Client, () => client0)
                    .Where(q => q.TypeOfClient == "juridic").Select(q => q.Client).List<Person>();
                var r2 = session.QueryOver<Order>(() => order).JoinAlias(() => order.Client, () => client0)
                    .Where(q => q.Material == "material2").List();
                var r3 = session.QueryOver<Order>().Left.JoinAlias(ord => ord.Client, () => client0)
                    .SelectList(list => list.Select(q => q.Material).WithAlias(() => orderde.Material)
                        .Select(() => client0.FirstName).WithAlias(() => orderde.FirstName))
                    .TransformUsing(Transformers.AliasToBean<OrderDe>()).List<OrderDe>();


                var r4 = session.QueryOver<Order>().Full.JoinAlias(ord => ord.Client, () => client0)
                    .Where(ord => (ord.Material != "material1" || ord.Material == null) &&
                                  (client0.FirstName != "rrr" || client0.FirstName == null))
                    .SelectList(list => list.Select(q => q.Material).WithAlias(() => orderde.Material)
                        .Select(() => client0.FirstName).WithAlias(() => orderde.FirstName))
                    .TransformUsing(Transformers.AliasToBean<OrderDe>()).List<OrderDe>();

                var r5 = session.QueryOver<Order>().Full.JoinAlias(ord => ord.Client, () => client0)
                    .Where(ord => (ord.Material != "material1" || ord.Material == null) &&
                                  (client0.FirstName != "rrr" || client0.FirstName == null))
                    .SelectList(list => list.Select(q => q.Material).WithAlias(() => orderde.Material)
                        .Select(() => client0.FirstName).WithAlias(() => orderde.FirstName))
                    .TransformUsing(Transformers.AliasToBean<OrderDe>()).List<OrderDe>()
                    .SingleOrDefault(ordde0 => ordde0.FirstName == null);

                var r6 = session.QueryOver<Order>().Full.JoinAlias(ord => ord.Client, () => client0)
                    .Where(ord => (ord.Material != "material1" || ord.Material == null) &&
                                  (client0.FirstName != "rrr" || client0.FirstName == null)).Select(Projections
                        .ProjectionList()
                        .Add(Projections.Property<Order>(ord => ord.Material).WithAlias(() => orderde.Material))
                        .Add(Projections.Property(() => client0.FirstName).WithAlias(() => orderde.FirstName))
                    ).TransformUsing(Transformers.AliasToBean<OrderDe>()).List<OrderDe>();

                var r7 = session.QueryOver<Client>()
                    .JoinAlias(cl => cl.Orders, () => order)
                    .Where(x => x.TypeOfClient == "fisic")
                    .List();

                var r8 = session.QueryOver<Order>(() => order)
                    .JoinQueryOver<Client>(ord => ord.Client, () => client)
                    .Where(cl => cl.FirstName == "rrr" || order.Material == "material1")
                    .Select(ord => ord.Client).List<Client>();

                var r9 = session.QueryOver<Order>(() => order)
                    .JoinQueryOver<Client>(ord => ord.Client, () => client)
                    .Where(cl => cl.FirstName == "rrr" || order.Material == "material1")
                    .List<Order>();
                MaterialFirstName materialfirstna = null;
                var r10 = session.QueryOver<Order>(() => order)
                    .JoinQueryOver<Client>(ord => ord.Client, () => cli)
                    .Where(cl => cl.FirstName == "rrr" || order.Material == "material1")
                    .SelectList(list => list
                        .Select(x => x.Material).WithAlias(() => materialfirstna.Material)
                        .Select(() => cli.FirstName).WithAlias(() => materialfirstna.FirstName)
                    )
                    .TransformUsing(Transformers.AliasToBean<MaterialFirstName>())
                    .List<MaterialFirstName>();

                var r11 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => cli)
                    .SelectList(list => list
                        .SelectGroup(() => cli.FirstName)
                        .SelectCount(ord => ord.Material)
                        .SelectMax(ord => ord.Quantity)
                    ).List<object[]>();
                GroupCl groupCl = null;
                var r12 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => cli)
                    .SelectList(list => list
                        .SelectGroup(() => cli.FirstName).WithAlias(() => groupCl.FirstName)
                        .SelectCount(ord => ord.Material).WithAlias(() => groupCl.Count)
                        .SelectMax(ord => ord.Quantity).WithAlias(() => groupCl.MaxQuantity)
                    )
                    .TransformUsing(Transformers.AliasToBean<GroupCl>())
                    .List<GroupCl>();

                var r13 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => cli)
                    .SelectList(list => list
                        .SelectGroup(() => cli.FirstName).WithAlias(() => groupCl.FirstName)
                        .SelectCount(ord => ord.Material).WithAlias(() => groupCl.Count)
                        .SelectMax(ord => ord.Quantity).WithAlias(() => groupCl.MaxQuantity)
                    ).Where(() => cli.FirstName != "qqq")
                    .TransformUsing(Transformers.AliasToBean<GroupCl>())
                    .List<GroupCl>();

                var r14 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => cli)
                    .SelectList(list => list
                        .SelectGroup(() => cli.FirstName).WithAlias(() => groupCl.FirstName)
                        .SelectCount(ord => ord.Material).WithAlias(() => groupCl.Count)
                        .SelectMax(ord => ord.Quantity).WithAlias(() => groupCl.MaxQuantity)
                    ).Where(Restrictions.Not(Restrictions.Eq(Projections.Group(() => cli.FirstName), "qqq")))
                    .TransformUsing(Transformers.AliasToBean<GroupCl>())
                    .List<GroupCl>();

                //se vor repeta clientii din cauza ca a facut inner join cu diferite ordere
                var r15 = session.QueryOver<Client>().JoinQueryOver(x => x.Orders, () => order)
                    .List();

                //nu se vor repeta clientii indiferent ca a facut inner join cu diferite ordere
                var r16 = session.QueryOver<Client>().JoinQueryOver(x => x.Orders, () => order)
                    .TransformUsing(Transformers.DistinctRootEntity)
                    .List();

                //nu se vor repeta clientii indiferent ca a facut inner join cu diferite ordere
                var r17 = session.QueryOver<Client>().JoinQueryOver(x => x.Orders, () => order)
                    .List().Distinct().ToList();

                //se vor repeta clientii indiferent ca a facut inner join cu diferite ordere
                var r18 = session.QueryOver<Client>().JoinQueryOver(x => x.Orders, () => order)
                    .TransformUsing(Transformers.RootEntity)
                    .List();

                //nu se vor repeta clientii indiferent ca a facut inner join cu diferite ordere
                var r19 = session.QueryOver<Client>().JoinQueryOver(x => x.Orders, () => order)
                    .TransformUsing(Transformers.RootEntity)
                    .Future();

                //se vor repeta clientii indiferent ca a facut inner join cu diferite ordere
                var r20 = session.QueryOver<Client>().JoinQueryOver(x => x.Orders, () => order)
                    .TransformUsing(Transformers.RootEntity)
                    .FutureValue();

                var r21 = r20;
                var r22 = r19.ToList();
                string str = r21.Value.FirstName;

                FirstNameCl firstNameCl = null;
                var r23 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => cli)
                    .SelectList(list => list.Select(() => cli.FirstName).WithAlias(() => firstNameCl.FirstName))
                    .TransformUsing(Transformers.AliasToBean<FirstNameCl>()).List<FirstNameCl>();

                var r24 = session.QueryOver<Order>(() => order).JoinAlias(x => x.Client, () => cli)
                    .SelectList(list => list
                        .SelectGroup(() => cli.FirstName).WithAlias(() => groupCl.FirstName)
                        .SelectCount(q => q.Material).WithAlias(() => groupCl.Count)
                        .SelectMax(q => q.UnitPrice).WithAlias(() => groupCl.MaxQuantity))
                    .Where(Restrictions.Gt(Projections.Max(() => order.UnitPrice), 200))
                    .TransformUsing(Transformers.AliasToBean<GroupCl>()).List<GroupCl>();

                var r25 = session.QueryOver<Client>().Inner.JoinAlias(x => x.Orders, () => order)
                    .TransformUsing(Transformers.DistinctRootEntity)
                    .List();
                var r26 = session.QueryOver<Person>()
                    .SelectList(list => list
                        .Select(p => p.FirstName).WithAlias(() => firstNameCl.FirstName)
                    )
                    .TransformUsing(Transformers.AliasToBean<FirstNameCl>())
                    .List<FirstNameCl>();

                var r27 = session.QueryOver<Client>().Inner.JoinAlias(x => x.Orders, () => order)
                    .TransformUsing(Transformers.DistinctRootEntity)
                    .Future();
                var r28 = session.QueryOver<Person>()
                    .SelectList(list => list
                        .Select(p => p.FirstName).WithAlias(() => firstNameCl.FirstName)
                    )
                    .TransformUsing(Transformers.AliasToBean<FirstNameCl>())
                    .FutureValue<FirstNameCl>();
                var r29 = r27.ToList();
                var r30 = r28.Value;

                // ------------------------------------------advanced query over---------------------------------------

                var q1 = QueryOver.Of<Client>().Where(x => x.Id == order.Client.Id).Select(x => x.FirstName);
                var r31 = session.QueryOver<Order>(() => order).WithSubquery.WhereNotExists(q1).List();

                var r32 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => cli)
                    .Where(new Disjunction()
                        .Add(Restrictions.Where<Order>(x => x.Material == "material1"))
                        .Add(Restrictions.Where<Order>(x => x.Material == "material11")))
                    .List();
                var r33 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => cli)
                    .Where(new Conjunction()
                        .Add(Restrictions.Where<Order>(x => x.Material == "material11"))
                        .Add(Restrictions.Where<Client>(x => cli.FirstName == "rrr")))
                    .List();

                var r34 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => cli)
                    .Where(x => x.Material == "material11")
                    .And(x => cli.FirstName == "rrr") //Or nu poate fi folosit ca And, nu este
                    .List();
                //rezultatul e clientul care are orderul cu unitprice maximal
                var r35 = session.QueryOver<Client>()
                    .WithSubquery
                    .Where(c => c.Id == QueryOver.Of<Order>()
                                    .Select(x => x.Client.Id)
                                    .OrderBy(x => x.UnitPrice)
                                    .Desc
                                    .Take(1)
                                    .As<int>())
                    .SingleOrDefault();

                //rezultatul va fi lista de clienti cu numarul de ordere ce apartin clientului
                var r36 = session.QueryOver<Client>(() => cli)
                    .SelectList(list => list
                        .Select(Projections.ProjectionList()
                            .Add(Projections.Property<Client>(x => x.Id))
                            .Add(Projections.Property<Client>(x => x.FirstName))
                            .Add(Projections.Property<Client>(x => x.LastName))
                        )
                        .SelectSubQuery(QueryOver.Of<Order>()
                            .Where(y => y.Client.Id == cli.Id)
                            .SelectList(list1 => list1.SelectCount(y => y.Id))
                        )
                    ).List<object[]>();

                var r37 = QueryOver.Of<Client>().Where(x => x.FirstName == "rrr").Select(x => x.Id);
                //resultaul sin orderele care au clientul cu numele rrr
                var r38 = session.QueryOver<Order>().WithSubquery.WhereProperty(y => y.Client.Id).In(r37).List();

                var r39 = QueryOver.Of<Order>().Where(x => x.Client.Id == client0.Id).Select(x => x.UnitPrice);
                //.OrderBy(x => x.UnitPrice).Desc.Take(1);
                //rezultatul va fi orderele care au unitprice maxim din grupa de ordere ce apartine clientului 
                var r40 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => client0).WithSubquery
                    .WhereAll(x => x.UnitPrice >= r39.As<decimal>()).List();

                //rezultatul va fi acei clienti care nu au ordere
                var r41 = session.QueryOver<Client>(() => cli).WithSubquery
                    .WhereNotExists(QueryOver.Of<Order>()
                        .Where(x => x.Client.Id == cli.Id)
                        .Select(x => x.Id)
                    ).List();

                var r42 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => client0).SelectList(list => list
                        .Select(x => x.Material).Select(x => x.UnitPrice).Select(() => client0.FirstName)
                        .Select(Projections.Conditional(Restrictions.Where<Order>(x => x.UnitPrice >= 100),
                            Projections.Constant("more then 100"),
                            Projections.Constant("less then 100")))
                    )
                    .List<object[]>();

                //query format conditional
                var query = session.QueryOver<Order>();
                if (1 == 1)
                    query.Where(x => x.UnitPrice > 100);
                else
                    query.Where(x => x.UnitPrice < 100);
                var r43 = query.SelectList(list => list
                                                   .Select(x => x.Material)
                                                   .Select(x => x.UnitPrice)
                                                   .Select(x => x.Quantity)
                                           )
                                           .List<object[]>();
                //extension method
                var r44 = session.QueryOver<Order>()
                                .ApplyFilter(100, true)
                                .SelectList(list => list
                                    .Select(x => x.Material)
                                    .Select(x => x.UnitPrice)
                                    .Select(x => x.Quantity)
                                )
                                .List<object[]>();

                //caonditia scrisa in where va fi pastrat in IQueryOver
                var query1 = session.QueryOver<Order>()
                    .ApplyFilter(100, true);

                query1.SelectList(list => list
                        .Select(x => x.Material)
                        .Select(x => x.UnitPrice)
                        .Select(x => x.Quantity)
                    )
                    .List<object[]>();
               
                //in selectie se foloseste functia FLOOR din sql
                var r45 = session.QueryOver<Order>().JoinAlias(x => x.Client, () => client0)
                        .SelectList(list => list
                                            .Select(x => x.Material)
                                            .Select(x => x.UnitPrice)
                                            .Select(() => client0.FirstName)
                                            .Select(Projections.SqlFunction("FLOOR", NHibernateUtil.Int32, Projections.Property<Order>(x => x.UnitPrice)))
                                   )
                    .List<object[]>();
            }

        }




    }

    public static class ExtClass
    {
        public static IQueryOver<Order, Order> ApplyFilter(this IQueryOver<Order, Order> query, decimal quantity, bool more)
        {
            if (more)
                query.Where(x => x.Quantity >= quantity);
            else
                query.Where(x => x.Quantity < quantity);

            return query;
        }

    }
}
