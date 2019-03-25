using Domain.Users;
using Persistence.Commons.Contracts;

namespace Persistence.Users.Contracts
{
    public interface IUserRepository : IEditableRepository<User>
    {
        User GetByIdValue(string idValue);
    }
}