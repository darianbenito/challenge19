using Domain.Users;

namespace Application.Users.Commands.AddUser
{
    public interface IAddUserCommand
    {
        void Execute(User user);
    }
}
