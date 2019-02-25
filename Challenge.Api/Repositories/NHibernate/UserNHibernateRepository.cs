using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.Api.Extensions;
using Challenge.Api.Models.Domain;
using Challenge.Api.Repositories.Contracts;
using Challenge.Api.Repositories.NHibernate.Commons;
using Challenge.Api.Repositories.NHibernate.Helpers;

namespace Challenge.Api.Repositories.NHibernate
{
    public class UserNHibernateRepository : BaseEditableNHibernateRepository<User>, IUserRepository
    {
        public UserNHibernateRepository(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }

        public override IList<User> GetAll()
        {
            return base.GetAll().SetTheOldest();
        }

        public override IList<User> GetAllPaginated(int pageSize, int page)
        {
            if (pageSize <= 0 || pageSize > 50) throw new ArgumentOutOfRangeException(nameof(pageSize));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));

            return GetAll()
                .OrderBy(u => u.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
        }

        public User GetByIdValue(string idValue)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                   return session.QueryOver<User>()
                       .Where(u => u.IdValue == idValue)
                       .SingleOrDefault();
                }
                catch (Exception)
                {
                    return default(User);
                }
            }
        }
    }
}