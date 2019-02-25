using System;
using System.Collections.Generic;
using System.Web.Http;
using Challenge.Api.Models.Commons;
using Challenge.Api.Repositories.Contracts.Commons;
// ReSharper disable UnusedMember.Global

namespace Challenge.Api.Controllers.Commons
{
    public class BaseReadonlyController<T> : ApiController where T: class, IEntity
    {
        private readonly IReadonlyRepository<T> _readonlyRepository;

        public BaseReadonlyController(IReadonlyRepository<T> readonlyRepository)
        {
            _readonlyRepository = readonlyRepository;
        }

        [HttpGet]
        public virtual T GetById(int id)
        {
            return _readonlyRepository.GetById(id);
        }

        [HttpGet]
        public virtual IList<T> GetAll()
        {
            return _readonlyRepository.GetAll();
        }

        [HttpGet]
        public virtual IList<T> GetAllPaginated(int pageSize, int page)
        {
            if (pageSize <= 0 || pageSize > 50) throw new ArgumentOutOfRangeException(nameof(pageSize));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));

            return _readonlyRepository.GetAllPaginated(pageSize, page);
        }
    }
}
