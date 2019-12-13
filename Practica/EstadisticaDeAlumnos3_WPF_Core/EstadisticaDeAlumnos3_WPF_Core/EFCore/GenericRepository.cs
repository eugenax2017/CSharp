using Common.Lib.Context.Interfaces;
using Common.Lib.Infrastructure;
using Common.Lib.Models.Core;
using EstadisticaDeAlumnos3_WPF_Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstadisticaDeAlumnos3_WPF_Core.EFCore
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ProjectDbContext _dbContext;
        public GenericRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual SaveResult<T> Add(T entity)
        {
            var output = new SaveResult<T>();

            if (entity.Id != default)
                throw new Exception("la entidad ya tiene id");

            entity.Id = Guid.NewGuid();
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            output.IsSuccess = true;
            output.Entity = entity;

            return output;
        }

        public T Find(Guid id)
        {
            return _dbContext.Set<T>().Where(x => x.Id==id).FirstOrDefault();
        }

        public IQueryable<T> QueryAll()
        {
            return _dbContext.Set<T>().AsQueryable();            
        }

        public SaveResult<T> Update(T entity)
        {
            var output = new SaveResult<T>();

            if (entity.Id == default)
                throw new Exception("This is Save, not Update!");
            
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();            
            output.IsSuccess = true;
            output.Entity = entity;
            
            return output;
        }

        public SaveResult<T> Delete(T entity)
        {
            var output = new SaveResult<T>();
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            output.IsSuccess = true;
            return output;
        }
    }
}

