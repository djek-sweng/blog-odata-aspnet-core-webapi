using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace ODataSample.Library.Repositories;

public interface IRepository<out T>
{
    IQueryable<T> Query { get; }
    IReadOnlyList<T> List { get; }
}