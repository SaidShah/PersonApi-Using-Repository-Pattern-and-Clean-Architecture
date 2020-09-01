using System.Linq;
using PersonApi.Interfaces;
using PersonApi.Models;

namespace PersonApi.Conductors
{
    public class RepositoryReadConductor<T> : IRepositoryReadConductor<T> where T : Entity
    {
        private IRepositoryRead<T> _repositoryRead;

        public RepositoryReadConductor(IRepositoryRead<T> repositoryRead)
        {
            _repositoryRead = repositoryRead;
        }
        
        public IResult<IQueryable<T>> FindAll()
        {
            var result = _repositoryRead.FindAll();
            if (result == null)
            {
                result.HasErrors = true;
                result.ResultObject = null;
            }
            
            return result;
        }

        public IResult<T> FindById(long id)
        {
            var result = _repositoryRead.FindById(id);

            if (result == null)
            {
                result.HasErrors = true;
                result.ResultObject = null;
            }

            return result;
        }
    }
}