using NHibernate;

namespace Challenge.Persistence.Commons.NHibernate.Helpers
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}
