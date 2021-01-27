using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sags.api.Data;

namespace sags.api.Repositories
{
    public abstract class Repository<TEntidad,TKey> where TEntidad : class
    {
       internal SagsContext _context;
       internal DbSet<TEntidad> _dbSet;

        protected Repository(SagsContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntidad>();
        }

        public virtual async Task Add(TEntidad nuevaEntidad)
        {
            await _dbSet.AddAsync(nuevaEntidad);
        }

        public virtual async Task<TEntidad> Find(TKey idEntidad)
        {
            return await _dbSet.FindAsync(idEntidad);
        }

        public virtual async Task<IEnumerable<TEntidad>> List(
            Expression<Func<TEntidad,bool>> filter = null,
            Func<IQueryable<TEntidad>,IOrderedQueryable<TEntidad>> orderBy = null,
            string includeProperties = ""
        )
        {
            IQueryable<TEntidad> query = _dbSet.AsQueryable<TEntidad>();
            if(filter != null) query.Where(filter);

            foreach(var includeProperty in includeProperties.Split(new char[]{','},
            StringSplitOptions.RemoveEmptyEntries)) query.Include(includeProperty);

            if(orderBy != null) return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual void Update(TEntidad enitidad)
        {
            _dbSet.Attach(enitidad);
            _context.Entry(enitidad).State = EntityState.Modified;
        }
    }
}