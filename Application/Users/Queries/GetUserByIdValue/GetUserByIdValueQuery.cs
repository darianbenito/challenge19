using Domain.Users;
using Persistence.Users.Contracts;

namespace Application.Users.Queries.GetUserByIdValue
{
    public class GetUserByIdValueQuery : IGetUserByIdValueQuery
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdValueQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Execute(string idValue)
        {
            return _userRepository.GetByIdValue(idValue);
        }
    }
}
