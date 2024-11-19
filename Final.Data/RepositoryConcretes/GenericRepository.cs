using Final.Core.Models;
using Final.Core.RepositoryAbstract;
using Final.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.RepositoryConcretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        DataContext _dataContext;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task AddAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
        }

        public int Commit()
        {
            return _dataContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
        }

        public T Get(Func<T, bool>? predicate = null)
        {
            return predicate == null ?
                _dataContext.Set<T>().FirstOrDefault() :
                _dataContext.Set<T>().FirstOrDefault(predicate);
        }

        public List<T> GetAll(Func<T, bool>? predicate = null)
        {
            return predicate == null ?
                _dataContext.Set<T>().ToList() :
                _dataContext.Set<T>().Where(predicate).ToList();
        }
    }
}