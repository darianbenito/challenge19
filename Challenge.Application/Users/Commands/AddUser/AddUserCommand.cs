using Challenge.Domain.Users;
using Challenge.Persistence.Users.Contracts;

namespace Challenge.Application.Users.Commands.AddUser
{
    public class AddUserCommand : IAddUserCommand
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(User user)
        {
            _userRepository.Add(user);
        }
    }
}
