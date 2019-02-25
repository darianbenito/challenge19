﻿using System.Collections.Generic;
using Challenge.Api.Models.Commons;

namespace Challenge.Api.Repositories.Contracts.Commons
{
    public interface IEditableRepository<T> : IReadonlyRepository<T> where T : class, IEntity
    {
        bool Add(T entity);

        bool AddAll(IEnumerable<T> entities);

        bool Update(T entity);

        bool Delete(T entity);
    }
}