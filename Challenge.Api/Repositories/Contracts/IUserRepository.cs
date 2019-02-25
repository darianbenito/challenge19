using Challenge.Api.Models.Domain;
using Challenge.Api.Repositories.Contracts.Commons;

namespace Challenge.Api.Repositories.Contracts
{
    public interface IUserRepository : IEditableRepository<User>
    {
        User GetByIdValue(string idValue);
    }
}