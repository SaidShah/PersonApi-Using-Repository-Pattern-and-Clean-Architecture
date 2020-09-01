using System.Collections.Generic;
using System.Linq;
using PersonApi.Models;

namespace PersonApi.Interfaces
{
    public interface IRepositoryReadConductor<T> where T : Entity
    {
        IResult<IQueryable<T>> FindAll();
        IResult<T> FindById(long id);
    }
}