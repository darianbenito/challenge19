using System.Collections.Generic;
using Domain.Commons;

namespace Persistence.Commons.Contracts
{
    public interface IReadonlyRepository<T> where T : class, IEntity
    {
        T GetById(int id);

        IList<T> GetAll();

        IList<T> GetAllPaginated(int pageSize, int page);
    }
}
