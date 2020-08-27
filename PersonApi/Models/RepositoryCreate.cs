using PersonApi.Interfaces;

namespace PersonApi.Models
{
    public class RepositoryCreate<T> : IRepositoryCreate<T> where T : Entity
    {
        private IRepository<T> _repository;

        public RepositoryCreate(IRepository<T> repository)
        {
            _repository = repository;
        }
        public IResult<T> Create(T obj)
        {
            return _repository.Create(obj);
        }
    }
}