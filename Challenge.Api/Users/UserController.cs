using System.Collections.Generic;
using System.Web.Http;
using Challenge.Application.Users.Commands.AddUser;
using Challenge.Application.Users.Commands.DeleteUser;
using Challenge.Application.Users.Commands.UpdateUser;
using Challenge.Application.Users.Queries.GetAllUsers;
using Challenge.Application.Users.Queries.GetUserByIdValue;
using Challenge.Domain.Users;

namespace Challenge.Api.Users
{
    public class UserController : ApiController
    {
        private readonly IAddUserCommand _addUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IUpdateUserCommand _updateUserCommand;
        private readonly IGetUserByIdValueQuery _getUserByIdValueQuery;
        private readonly IGetAllUsersQuery _getAllUsersQuery;

        public UserController(IAddUserCommand addUserCommand, IDeleteUserCommand deleteUserCommand,
            IUpdateUserCommand updateUserCommand, IGetUserByIdValueQuery getUserByIdValueQuery,
            IGetAllUsersQuery getAllUsersQuery)
        {
            _addUserCommand = addUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _updateUserCommand = updateUserCommand;
            _getUserByIdValueQuery = getUserByIdValueQuery;
            _getAllUsersQuery = getAllUsersQuery;
        }

        [HttpPost]
        [Route("api/User/AddUser")]
        public void AddUser(User user)
        {
            _addUserCommand.Execute(user);
        }

        [HttpDelete]
        [Route("api/User/DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            _deleteUserCommand.Execute(id);
        }

        [HttpPut]
        [Route("api/User/UpdateUser")]
        public void UpdateUser(User user)
        {
            _updateUserCommand.Execute(user);
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
