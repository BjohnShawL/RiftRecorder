using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using R_R.Database.Contexts;

namespace R_R.Database.Services
{
    public class DbReadService :IDbReadService
    {
        private R_RContext _db;

        public DbReadService(R_RContext db)
        {
            _db = db;
        }

        public async Task<List<TEntity>> GetAsync<TEntity>() where TEntity : class
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return await _db.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<TEntity> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return await _db.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return await _db.Set<TEntity>().AnyAsync(expression);
        }

        public void Include<TEntity>() where TEntity : class
        {
            var propertyNames = _db.Model.FindEntityType(typeof(TEntity)).GetNavigations().Select(e => e.Name);
            foreach (var propertyName in propertyNames)
            {
                _db.Set<TEntity>().Include(propertyName).Load();
            }
        }

        public void Include<TEntity1, TEntity2>() where TEntity1 : class where TEntity2 : class
        {
            Include<TEntity1>();
            Include<TEntity2>();
        }
    }
}
