using System;
using Enums;
using Model;
using Services;

namespace Views
{
  public class View : AbstractView
  {
    public View(SeriesService service) : base(service) { }

    public override void AddView()
    {
      Console.WriteLine("Input serie's title:");
      string title = Console.ReadLine();

      Console.WriteLine("Input serie's description:");
      string description = Console.ReadLine();

      Console.WriteLine("Input the serie's year:");
      string year = Console.ReadLine();

      Console.WriteLine("Choose the genre below");
      foreach (int i in Enum.GetValues(typeof(Genre)))
      {
        Console.WriteLine($"{i}. {Enum.GetName(typeof(Genre), i)}");
      }
      string genre = Console.ReadLine();

      Serie serie = _service.Add(title, description, genre, year);

      if (serie == null)
        AddView();

      Console.WriteLine($"Serie added\n{serie.ToString()}");
    }

    public override void DeleteView()
    {
      Console.WriteLine("Input the id to delete:");
      string id = Console.ReadLine();
      Console.WriteLine(_service.Delete(id));
    }

    public override void UpdateView()
    {
      Console.WriteLine("Input series ID:");
      string id = Console.ReadLine();

      Serie serie = _service.FindById(id);
      if (serie == null)
      {
        Console.WriteLine("Id not found.");
        return;
      }

      Console.WriteLine("Input serie's title:");
      string title = Console.ReadLine();

      Console.WriteLine("Input serie's description:");
      string description = Console.ReadLine();

      Console.WriteLine("Input the serie's year:");
      string year = Console.ReadLine();

      Console.WriteLine("Choose the genre below");
      foreach (int i in Enum.GetValues(typeof(Genre)))
      {
        Console.WriteLine($"{i}. {Enum.GetName(typeof(Genre), i)}");
      }
      string genre = Console.ReadLine();
      serie = _service.Update(id, title, description, genre, year);

      if (serie == null)
      {
        Console.WriteLine("Uptade failed.");
        return;
      }

      Console.WriteLine(serie);

    }
  }
}