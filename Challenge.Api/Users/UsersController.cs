using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Challenge.Application.Users.Commands.AddUser;
using Challenge.Application.Users.Commands.DeleteUser;
using Challenge.Application.Users.Commands.UpdateUser;
using Challenge.Application.Users.Queries.GetAllUsers;
using Challenge.Application.Users.Queries.GetAllUsersPaginated;
using Challenge.Application.Users.Queries.GetUserByIdValue;
using Challenge.Domain.Users;

namespace Challenge.Api.Users
{
    public class UsersController : ApiController
    {
        private readonly IAddUserCommand _addUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IUpdateUserCommand _updateUserCommand;
        private readonly IGetUserByIdValueQuery _getUserByIdValueQuery;
        private readonly IGetAllUsersQuery _getAllUsersQuery;
        private readonly IGetAllUsersPaginatedQuery _getAllUsersPaginatedQuery;

        public UsersController(IAddUserCommand addUserCommand,
            IDeleteUserCommand deleteUserCommand,
            IUpdateUserCommand updateUserCommand,
            IGetUserByIdValueQuery getUserByIdValueQuery,
            IGetAllUsersQuery getAllUsersQuery,
            IGetAllUsersPaginatedQuery getAllUsersPaginatedQuery)
        {
            _addUserCommand = addUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _updateUserCommand = updateUserCommand;
            _getUserByIdValueQuery = getUserByIdValueQuery;
            _getAllUsersQuery = getAllUsersQuery;
            _getAllUsersPaginatedQuery = getAllUsersPaginatedQuery;
        }

        [HttpPost]
        [Route("api/Users")]
        public IHttpActionResult AddUser(User user)
        {
            _addUserCommand.Execute(user);

            return Ok();
        }

        [HttpDelete]
        [Route("api/Users/{id:int}")]
        public IHttpActionResult DeleteUser(int id)
        {
            _deleteUserCommand.Execute(id);

            return Ok();
        }

        [HttpPut]
        [Route("api/Users")]
        public IHttpActionResult UpdateUser(User user)
        {
            _updateUserCommand.Execute(user);

            return Ok();
        }

        [HttpGet]
        [Route("api/Users")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetByIdValue(string idValue)
        {
            User user = _getUserByIdValueQuery.Execute(idValue);

            if (user == default(User))
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("api/Users")]
        [ResponseType(typeof(IList<User>))]
        public IHttpActionResult GetAllUsers()
        {
            IList<User> users = _getAllUsersQuery.Execute();

            if (users == default(IList<User>))
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet]
        [Route("api/Users")]
        [ResponseType(typeof(IList<User>))]
        public IHttpActionResult GetAllUsersPaginated(int pageSize, int page)
        {
            IList<User> users = _getAllUsersPaginatedQuery.Execute(pageSize, page);

            if (users == default(IList<User>))
            {
                return NotFound();
            }

            return Ok(users);
        }
    }
}
