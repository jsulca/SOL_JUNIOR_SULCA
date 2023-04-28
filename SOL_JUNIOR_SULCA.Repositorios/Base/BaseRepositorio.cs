using SOL_JUNIOR_SULCA.Contextos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SOL_JUNIOR_SULCA.Repositorios.Base
{
    public class BaseRepositorio<T> where T : class
    {
        protected readonly DataBaseContexto _contexto;

        public BaseRepositorio(DataBaseContexto contexto)
        {
            _contexto = contexto;
        }

        public T GetOne(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().SingleOrDefault(predicate);

        public Task<T> GetOneAsync(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().SingleOrDefaultAsync(predicate);

        public List<T> GetAllBy(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().Where(predicate).ToList();

        public Task<List<T>> GetAllByAsync(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().Where(predicate).ToListAsync();

        public int CountBy(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().Count(predicate);

        public int Count() => _contexto.Set<T>().Count();

        public Task<int> CountByAsync(Expression<Func<T, bool>> predicate) => _contexto.Set<T>().CountAsync(predicate);

        public List<T> GetAll() => _contexto.Set<T>().ToList();

        public Task<List<T>> GetAllAsync() => _contexto.Set<T>().ToListAsync();


        public void Save(T entidad) => _contexto.Entry(entidad).State = System.Data.Entity.EntityState.Added;

        public void Save(List<T> entities) => entities.ForEach(x => _contexto.Entry(x).State = EntityState.Added);

        public void Update(T entity) => _contexto.Entry(entity).State = EntityState.Modified;

        public void Update(List<T> entities) => entities.ForEach(x => _contexto.Entry(x).State = EntityState.Modified);

        public void Remove(T entity) => _contexto.Entry(entity).State = EntityState.Deleted;

        public void Remove(List<T> entities) => entities.ForEach(x => _contexto.Entry(x).State = EntityState.Deleted);

    }
}
