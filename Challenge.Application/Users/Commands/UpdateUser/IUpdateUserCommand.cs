using Challenge.Domain.Users;

namespace Challenge.Application.Users.Commands.UpdateUser
{
    public interface IUpdateUserCommand
    {
        void Execute(User user);
    }
}
