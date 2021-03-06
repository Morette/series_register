using System;

namespace Entities
{
  public abstract class BaseEntity
  {
    public Guid Id { get; protected set; }
  }
}