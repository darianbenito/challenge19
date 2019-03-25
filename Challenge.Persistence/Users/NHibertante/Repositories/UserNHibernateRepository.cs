using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.Domain.Users;
using Challenge.Domain.Users.Extensions;
using Challenge.Persistence.Commons.NHibernate.Helpers;
using Challenge.Persistence.Commons.NHibernate.Repositories;
using Challenge.Persistence.Users.Contracts;

namespace Challenge.Persistence.Users.NHibertante.Repositories
{
    public class UserNHibernateRepository : BaseEditableNHibernateRepository<User>, IUserRepository
    {
        public UserNHibernateRepository(INHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
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
    }
}