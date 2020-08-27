using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonApi.Interfaces;
using PersonApi.Models;

namespace PersonApi.Data
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
            
        }
        
        public virtual DbSet<Person> Persons { get; set; }
        
        public void Add<T>(T entity) where T : class => base.Add(entity);
        public IQueryable<T> Query<T>() where T : class => base.Set<T>();

        public void Update<T>(T entity) where T : class
        {
            var set = base.Set<T>();

            if (!set.Local.Any(e => e == entity))
            {
                set.Attach(entity);
            }
        }
    }
}