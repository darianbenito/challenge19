using Challenge.Persistence.Users.NHibertante.Mappers;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Challenge.Persistence.Commons.NHibernate.Helpers
{
    public class NHibernateHelper : INHibernateHelper
    {
        private readonly string _connectionString;
        private readonly object _lockObject = new object();
        private static ISessionFactory _sessionFactory;

        public NHibernateHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    CreateSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private void CreateSessionFactory()
        {
            lock (_lockObject)
            {
                var fluentConfiguration = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.ConnectionString(_connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMapper>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LocationMapper>())
                    .BuildConfiguration();

                var exporter = new SchemaExport(fluentConfiguration);
                exporter.Execute(true, true, false);

                _sessionFactory = fluentConfiguration.BuildSessionFactory();
            }
        }
    }
}
