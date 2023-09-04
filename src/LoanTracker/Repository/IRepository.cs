using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LoanTracker;

public interface IRepository<T> where T : class
{
    IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, bool ascending = true);

    T GetById(object id);

    T Insert(T entity);

    bool Update(T entity);

    bool Delete(object id);
}