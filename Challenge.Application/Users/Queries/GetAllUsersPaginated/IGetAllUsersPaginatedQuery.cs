using System.Collections.Generic;
using Challenge.Domain.Users;

namespace Challenge.Application.Users.Queries.GetAllUsersPaginated
{
    public interface IGetAllUsersPaginatedQuery
    {
        IList<User> Execute(int pageSize, int page);
    }
}
