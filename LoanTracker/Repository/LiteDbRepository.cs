using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LoanTracker;

public class LiteDbRepository<T> : IRepository<T> where T : class
{
    private readonly ILiteCollection<T> _collection;

    public LiteDbRepository(ILiteDatabase database, string collection) => _collection = database.GetCollection<T>(collection);

    public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, bool ascending = true)
    {
        var query = _collection.Query();

        if (filter != null)
            query.Where(filter);

        if (orderBy != null)
        {
            if (ascending)
                query.OrderBy(orderBy);
            else
                query.OrderByDescending(orderBy);
        }

        return query.ToList();
    }

    public T GetById(object id) => _collection.FindOne($"$._id = {id}");

    public T Insert(T entity)
    {
        var result = _collection.Insert(entity);
        return GetById(result);
    }

    public bool Update(T entity) => _collection.Update(entity);

    public bool Delete(object id) => _collection.Delete(new BsonValue(id));
}