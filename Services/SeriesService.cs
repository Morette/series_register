using System;
using System.Collections.Generic;
using Interfaces;
using Repositories;
using Enums;
using Model;

namespace Services
{
  public class SeriesService : IService<Serie>
  {
    private SeriesRepository _repository;

    public SeriesService()
    {
      this._repository = new SeriesRepository();
    }

    public string Delete(string id)
    {
      Serie serie = FindById(id);

      if (serie == null)
        return "Serie not found to delete.";

      _repository.Delete(serie);
      return "Serie deleted.";
    }

    public Serie Add(string title, string description, string genre, string year)
    {
      bool hasValidGenreAndYear = ValidateGenreAndYear(year, genre);

      if (!hasValidGenreAndYear)
        return null;

      Serie serie = new Serie((Genre)Enum.Parse(typeof(Genre), genre), title, description, int.Parse(year));

      _repository.Add(serie);
      return serie;
    }

    public void List()
    {
      List<Serie> series = _repository.List();

      if (series.Count == 0)
      {
        Console.WriteLine("Your series list is empty.");
        return;
      }

      series.ForEach(serie => Console.WriteLine(serie.ToString()));
    }

    public Serie FindById(string id)
    {
      Serie serie = _repository.SearchId(Guid.Parse(id));
      return serie != null ? serie : null;
    }

    public Serie Update(string id, string title, string description, string genre, string year)
    {
      Serie s = FindById(id);

      if (s == null)
      {
        Console.WriteLine("Serie not found to be updated.");
        return null;
      }

      bool hasValidGenreAndYear = ValidateGenreAndYear(year, genre);
      if (!hasValidGenreAndYear)
        return null;

      s.Title = title;
      s.Description = description;
      s.Year = int.Parse(year);
      s.Genre = (Genre)Enum.Parse(typeof(Genre), genre);

      _repository.Update(s);
      Console.WriteLine("Serie upated.");
      return s;
    }

    private bool ValidateGenreAndYear(string year, string genre)
    {
      int parsedYear = 0;

      if (!Enum.IsDefined(typeof(Genre), int.Parse(genre)))
      {
        Console.WriteLine("Please, choose a valid genre option");
        return false;
      }

      if (!int.TryParse(year, out parsedYear) || !(parsedYear.ToString().Length == 4))
      {
        Console.WriteLine("Please, input a valid year. Make sure it has four digits.");
        return false;
      }

      return true;
    }
  }
}