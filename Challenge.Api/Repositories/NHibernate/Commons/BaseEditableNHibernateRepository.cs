using System;
using System.Collections.Generic;
using Challenge.Api.Models.Commons;
using Challenge.Api.Repositories.Contracts.Commons;
using Challenge.Api.Repositories.NHibernate.Helpers;

namespace Challenge.Api.Repositories.NHibernate.Commons
{
    public class BaseEditableNHibernateRepository<T> : BaseReadonlyNHibernateRepository<T>, IEditableRepository<T> where T : class, IEntity
    {
        protected BaseEditableNHibernateRepository(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }

        public virtual bool Add(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        return false;
                    }
                }
            }

            return true;
        }

        public virtual bool AddAll(IEnumerable<T> entities)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var entity in entities)
                        {
                            session.Save(entity);
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        return false;
                    }
                }
            }

            return true;
        }

        public virtual bool Update(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        return false;
                    }
                }
            }

            return true;
        }

        public virtual bool Delete(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var queryString = $"delete {typeof(T)} where id = :id";

                        session.CreateQuery(queryString)
                            .SetParameter("id", entity.Id)
                            .ExecuteUpdate();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        return false;
                    }
                }
            }

            return true;
        }
    }
}