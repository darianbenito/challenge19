using System.Collections.Generic;
using Challenge.Api.Models.Commons;

namespace Challenge.Api.Repositories.Contracts.Commons
{
    public interface IReadonlyRepository<T> where T : class, IEntity
    {
        T GetById(int id);

        IList<T> GetAll();

        IList<T> GetAllPaginated(int pageSize, int page);
    }
}
