using System.Web.Http;
using Challenge.Api.Controllers.Commons;
using Challenge.Api.Models.Domain;
using Challenge.Api.Repositories.Contracts;

namespace Challenge.Api.Controllers
{
    public class UserController : BaseEditableController<User>
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("api/User/GetByIdValue/{idValue}")]
        public User GetByIdValue(string idValue)
        {
            return _userRepository.GetByIdValue(idValue);
        }
    }
}
