using System.Web.Http;
using Challenge.Api.Models.Commons;
using Challenge.Api.Repositories.Contracts.Commons;
// ReSharper disable UnusedMember.Global

namespace Challenge.Api.Controllers.Commons
{
    public class BaseEditableController<T> : BaseReadonlyController<T> where T : class, IEntity
    {
        private readonly IEditableRepository<T> _editableRepository;

        public BaseEditableController(IEditableRepository<T> editableRepository) : base(editableRepository)
        {
            _editableRepository = editableRepository;
        }

        [HttpPost]
        public virtual bool Add([FromBody]T entity)
        {
            return _editableRepository.Add(entity);
        }

        [HttpPut]
        public virtual bool Update([FromBody]T entity)
        {
            return _editableRepository.Update(entity);
        }

        [HttpDelete]
        public virtual bool Delete([FromBody]T entity)
        {
            return _editableRepository.Delete(entity);
        }
    }
}
