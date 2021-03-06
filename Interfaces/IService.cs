using System;

namespace Interfaces
{
  public interface IService<T>
  {
    public void List();
    public T FindById(string id);
    public T Add(string title, string description, string genre, string year);
    public string Delete(string id);
    public T Update(string id, string title, string description, string genre, string year);
  }
}