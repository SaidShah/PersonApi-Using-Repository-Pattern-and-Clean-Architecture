using System.Collections.Generic;
using System.Linq;
using PersonApi.Models;

namespace PersonApi.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IResult<T> FindById(long id);
       IResult<IQueryable<T>> FindAll();
       IResult<T> Create(T obj);
    }
}