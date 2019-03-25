using System.Collections.Generic;
using Challenge.Domain.Commons;

namespace Challenge.Persistence.Commons.Contracts
{
    public interface IEditableRepository<T> : IReadonlyRepository<T> where T : class, IEntity
    {
        bool Add(T entity);

        bool AddAll(IEnumerable<T> entities);

        bool Update(T entity);

        bool Delete(T entity);
    }
}