using Challenge.Domain.Users;
using Challenge.Persistence.Commons.Contracts;

namespace Challenge.Persistence.Users.Contracts
{
    public interface IUserRepository : IEditableRepository<User>
    {
        User GetByIdValue(string idValue);
    }
}