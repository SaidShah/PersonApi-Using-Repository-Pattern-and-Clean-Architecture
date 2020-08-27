using System;
using PersonApi.Interfaces;

namespace PersonApi.Models
{
    public class RepositoryCreateConductor<T> : IRepositoryCreateConductor<T> where T : Entity
    {
        private IRepositoryCreate<T> _repositoryCreate;

        public RepositoryCreateConductor(IRepositoryCreate<T> repositoryCreate)
        {
            _repositoryCreate = repositoryCreate;
        }
        public IResult<T> Create(T obj)
        {
            var created = _repositoryCreate.Create(obj);

            return created;
        }
    }
}