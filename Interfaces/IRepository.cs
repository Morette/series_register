using System;
using System.Collections.Generic;

namespace Interfaces
{
  public interface IRepository<T>
  {
    public List<T> List();
    public T SearchId(Guid id);
    void Add(T t);
    void Delete(T t);
    void Update(T t);
  }
}