using NHibernate;

namespace Challenge.Api.Repositories.NHibernate.Helpers
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}
