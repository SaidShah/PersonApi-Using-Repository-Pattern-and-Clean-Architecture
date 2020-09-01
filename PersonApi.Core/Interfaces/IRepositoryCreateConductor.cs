using PersonApi.Models;

namespace PersonApi.Interfaces
{
    public interface IRepositoryCreateConductor<T> where T : Entity
    {
        IResult<T> Create(T obj);
    }
}