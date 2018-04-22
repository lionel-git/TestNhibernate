using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;


using System.Reflection;

namespace TestNhibernate
{
    class Program
    {
        const string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Test()
        {
            var cfg = new Configuration();

            cfg.DataBaseIntegration(x => { x.ConnectionString = conString; x.Driver<SqlClientDriver>(); x.Dialect<MsSql2012Dialect>(); } );

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sefact = cfg.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {

                    //perform database logic 
                    tx.Commit();
                }
                Console.WriteLine("Wait readline...");
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            Test();
            // Data Source=(localdb)\ProjectsV13;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

        }
    }
}
