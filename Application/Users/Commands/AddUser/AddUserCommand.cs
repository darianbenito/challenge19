using Domain.Users;
using Persistence.Users.Contracts;

namespace Application.Users.Commands.AddUser
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
