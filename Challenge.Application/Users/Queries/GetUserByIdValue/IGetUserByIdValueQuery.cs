using Challenge.Domain.Users;

namespace Challenge.Application.Users.Queries.GetUserByIdValue
{
    public interface IGetUserByIdValueQuery
    {
        User Execute(string idValue);
    }
}
