using System.Linq;
using PersonApi.Interfaces;
using PersonApi.Models;

namespace PersonApi.Infrastructure
{
    public class RepositoryRead<T> : IRepositoryRead<T> where T : Entity
    {
        private IRepository<T> _repository;

        public RepositoryRead(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IResult<IQueryable<T>> FindAll()
        {
           return _repository.FindAll();
        }

        public IResult<T> FindById(long id)
        {
            return _repository.FindById(id);
        }
    }
}