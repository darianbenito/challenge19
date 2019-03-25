using System.Collections.Generic;
using Domain.Users;

namespace Application.Users.Queries.GetAllUsers
{
    public interface IGetAllUsersQuery
    {
        IList<User> Execute();
    }
}
