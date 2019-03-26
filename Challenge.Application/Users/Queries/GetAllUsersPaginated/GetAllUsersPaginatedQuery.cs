using System.Collections.Generic;
using Challenge.Domain.Users;
using Challenge.Persistence.Users.Contracts;

namespace Challenge.Application.Users.Queries.GetAllUsersPaginated
{
    public class GetAllUsersPaginatedQuery : IGetAllUsersPaginatedQuery
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersPaginatedQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> Execute(int pageSize, int page)
        {
            return _userRepository.GetAllPaginated(pageSize, page);
        }
    }
}
