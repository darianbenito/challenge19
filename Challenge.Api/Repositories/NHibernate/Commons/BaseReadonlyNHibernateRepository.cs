using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.Api.Models.Commons;
using Challenge.Api.Repositories.Contracts.Commons;
using Challenge.Api.Repositories.NHibernate.Helpers;

namespace Challenge.Api.Repositories.NHibernate.Commons
{
    public class BaseReadonlyNHibernateRepository<T> : IReadonlyRepository<T> where T : class, IEntity
    {
        protected readonly INHibernateHelper NHibernateHelper;

        protected BaseReadonlyNHibernateRepository(INHibernateHelper nHibernateHelper)
        {
            NHibernateHelper = nHibernateHelper;
        }

        public virtual T GetById(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.Get<T>(id);

                }
                catch (Exception)
                {
                    return default(T);
                }
            }
        }

        public virtual IList<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.Query<T>().ToList();
                }
                catch (Exception)
                {
                    return default(IList<T>);
                }
            }
        }

        public virtual IList<T> GetAllPaginated(int pageSize, int page)
        {
            return GetAll()
                .OrderBy(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
        }
    }
}