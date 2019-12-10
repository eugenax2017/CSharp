using Common.Lib.Infrastructure;
using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Lib.Context.Interfaces
{
    public interface IRepository<T>  where T : Entity
    {
        IQueryable<T> QueryAll();

        T Find(Guid id);

        SaveResult<T> Add(T entity);

        SaveResult<T> Update(T entity);
    }
}
