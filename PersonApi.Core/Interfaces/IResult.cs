using System.Collections.Generic;
namespace PersonApi.Interfaces
{
    public interface IResult<T>
    {
        T ResultObject { get; set; }
        bool HasErrors { get; set; }
    }
}