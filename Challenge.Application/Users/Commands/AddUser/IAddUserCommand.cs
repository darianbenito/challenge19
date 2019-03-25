using Challenge.Domain.Users;

namespace Challenge.Application.Users.Commands.AddUser
{
    public interface IAddUserCommand
    {
        void Execute(User user);
    }
}
