using NHibernate;

namespace Persistence.Commons.NHibernate.Helpers
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}
