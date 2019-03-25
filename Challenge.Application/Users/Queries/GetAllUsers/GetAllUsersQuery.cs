using System.Collections.Generic;
using Challenge.Domain.Users;
using Challenge.Persistence.Users.Contracts;

namespace Challenge.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IGetAllUsersQuery
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> Execute()
        {
            return _userRepository.GetAll();
        }
    }
}
