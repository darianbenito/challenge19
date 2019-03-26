using Challenge.Persistence.Users.Contracts;

namespace Challenge.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
