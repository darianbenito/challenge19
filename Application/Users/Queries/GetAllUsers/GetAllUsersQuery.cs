using System.Collections.Generic;
using Domain.Users;
using Persistence.Users.Contracts;

namespace Application.Users.Queries.GetAllUsers
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
