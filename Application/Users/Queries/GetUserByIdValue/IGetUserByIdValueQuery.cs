using Domain.Users;

namespace Application.Users.Queries.GetUserByIdValue
{
    public interface IGetUserByIdValueQuery
    {
        User Execute(string idValue);
    }
}
