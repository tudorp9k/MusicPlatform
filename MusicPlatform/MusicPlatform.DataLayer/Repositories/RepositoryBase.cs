using Microsoft.EntityFrameworkCore;
using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    internal class RepositoryBase<T> where T : BaseEntity
    {
        protected readonly MusicDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public RepositoryBase(MusicDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        /// <summary>
        ///     This method will actually remove the row from the database.
        /// </summary>
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public List<T> GetAll()
        {
            return GetRecords().ToList();
        }

        public bool Any(Func<T, bool> expression)
        {
            return GetRecords().Any(expression);
        }

        protected IQueryable<T> GetRecords()
        {
            return dbSet.AsQueryable<T>();
        }
    }
}
