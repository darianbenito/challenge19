using System;
using System.Collections.Generic;
using Challenge.Api.Models.Commons;
using Challenge.Api.Repositories.Contracts.Commons;

namespace Challenge.Api.Repositories.Dapper.Commons
{
    public class BaseReadonlyDapperRepository<T> : IReadonlyRepository<T> where T : class, IEntity
    {
        protected BaseReadonlyDapperRepository()
        {
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAllPaginated(int pageSize, int page)
        {
            throw new NotImplementedException();
        }
    }
}