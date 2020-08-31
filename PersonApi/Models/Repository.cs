using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using PersonApi.Data;
using PersonApi.Interfaces;

namespace PersonApi.Models
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public readonly IContext Context;
        public IQueryable<T> Query { get; private set; }

        public Repository(IContext context)
        {
            Context = context;
            Query = context.Query<T>();
        }

        public IResult<T> FindById(long id)
        {
            var result = new Result<T>();
            result.ResultObject = Query.FirstOrDefault(e => e.Id == id);
            return result;
        }

        public virtual IResult<IQueryable<T>> FindAll()
        {
            var result = new Result<IQueryable<T>>();
            result.ResultObject = Context.Query<T>();
            return result;
        }

        public IResult<T> Create(T person)
        {
            var result = new Result<T>();
            Context.Add(person);
            var totalRecordsSaved = Context.SaveChanges();
            result.HasErrors = totalRecordsSaved <= 0;
            return result;
        }
    }
}