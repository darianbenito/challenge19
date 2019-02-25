using System;
using System.Collections.Generic;
using Challenge.Api.Models.Commons;
using Challenge.Api.Repositories.Contracts.Commons;

// ReSharper disable RedundantAnonymousTypePropertyName

namespace Challenge.Api.Repositories.Dapper.Commons
{
    public class BaseEditableDapperRepository<T> : BaseReadonlyDapperRepository<T>, IEditableRepository<T> where T : class, IEntity
    {
        protected BaseEditableDapperRepository()
        {
        }

        public virtual bool Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool AddAll(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}