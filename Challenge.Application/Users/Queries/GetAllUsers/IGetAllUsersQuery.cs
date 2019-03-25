using System.Collections.Generic;
using Challenge.Domain.Users;

namespace Challenge.Application.Users.Queries.GetAllUsers
{
    public interface IGetAllUsersQuery
    {
        IList<User> Execute();
    }
}
