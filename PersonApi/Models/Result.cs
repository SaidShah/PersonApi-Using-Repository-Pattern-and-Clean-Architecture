using System.Collections.Generic;
using PersonApi.Interfaces;

namespace PersonApi.Models
{
    public class Result<T> : IResult<T>
    {        
            public T ResultObject { get; set; }
             public bool HasErrors { get; set; }
             
             public Result() {}
             
             public Result(T resultObject)
             {
                 ResultObject = resultObject;
             }
             
             public Result(T resultObject, bool hasErrors)
             {
                 ResultObject = resultObject;
                 HasErrors = hasErrors;
             }

    }
}