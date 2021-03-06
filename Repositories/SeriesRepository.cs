
using System;
using System.Collections.Generic;
using Model;
using Interfaces;

namespace Repositories
{
  public class SeriesRepository : IRepository<Serie>
  {
    private List<Serie> _series = new List<Serie>();

    public void Delete(Serie serie)
    {
      _series.Remove(serie);
    }

    public void Add(Serie serie)
    {
      _series.Add(serie);
    }

    public List<Serie> List()
    {
      return _series;
    }

    public Serie SearchId(Guid id)
    {
      return _series.Find(serie => serie.Id == id);
    }

    public void Update(Serie serie)
    {
      Serie s1 = this.SearchId(serie.Id);
      s1 = serie;
    }
  }
}