using System.Collections.Generic;
using System.Web.Http;
using Application.Users.Commands.AddUser;
using Application.Users.Queries.GetAllUsers;
using Application.Users.Queries.GetUserByIdValue;
using Domain.Users;

namespace Challenge.Api.Users
{
    public class UserController : ApiController
    {
        private readonly IAddUserCommand _addUserCommand;
        private readonly IGetUserByIdValueQuery _getUserByIdValueQuery;
        private readonly IGetAllUsersQuery _getAllUsersQuery;

        public UserController(IAddUserCommand addUserCommand, IGetUserByIdValueQuery getUserByIdValueQuery, IGetAllUsersQuery getAllUsersQuery)
        {
            _addUserCommand = addUserCommand;
            _getUserByIdValueQuery = getUserByIdValueQuery;
            _getAllUsersQuery = getAllUsersQuery;
        }

        [HttpPost]
        [Route("api/User/AddUser")]
        public void AddUser(User user)
        {
            _addUserCommand.Execute(user);
        }

        [HttpGet]
        [Route("api/User/GetByIdValue/{idValue}")]
        public User GetByIdValue(string idValue)
        {
            return _getUserByIdValueQuery.Execute(idValue);
        }

        [HttpGet]
        [Route("api/User/GetAllUsers")]
        public IList<User> GetAllUsers()
        {
            return _getAllUsersQuery.Execute();
        }
    }
}
