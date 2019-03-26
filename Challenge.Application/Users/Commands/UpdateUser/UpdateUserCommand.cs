using Challenge.Domain.Users;
using Challenge.Persistence.Users.Contracts;

namespace Challenge.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(User user)
        {
            _userRepository.Update(user);
        }
    }
}
