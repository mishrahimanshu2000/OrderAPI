using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Order.Data.Data;
using Order.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public DbSet<T> DbSet { get; set; }

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            this.DbSet = _context.Set<T>();
        }

        public EntityEntry<T> Add(T entity)
        {
            return this.DbSet.Add(entity);
        }

        public EntityEntry<T> Delete(T entity)
        { 
            return this.DbSet.Remove(entity);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await this.DbSet.Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }
        

        public EntityEntry<T> Update(T entity)
        {
            return this.DbSet.Update(entity);
        }
    }
}
