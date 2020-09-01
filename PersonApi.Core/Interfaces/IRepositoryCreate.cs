using PersonApi.Models;

namespace PersonApi.Interfaces
{
    public interface IRepositoryCreate<T> where T : Entity
    {
        IResult<T> Create(T obj);
    }
}