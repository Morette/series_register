using System;
using Services;
using Views;

namespace Controller
{
  public class SeriesController
  {
    private SeriesService _service = new SeriesService();

    public void Start()
    {
      View view = new View(_service);
      Execute(view);
    }

    public void Execute(View view)
    {
      switch (GetUserOption())
      {
        case "1":
          _service.List();
          break;
        case "2":
          view.AddView();
          break;
        case "3":
          view.UpdateView();
          break;
        case "4":
          view.DeleteView();
          break;
        default:
          Console.WriteLine("Please, choose a valid option.");
          break;
      }

      Execute(view);
    }

    private string GetUserOption()
    {
      Console.WriteLine("\nDot Series at your service.");
      Console.WriteLine("Choose an option:");

      Console.WriteLine("\n1 - List");
      Console.WriteLine("2 - Insert new");
      Console.WriteLine("3 - Update");
      Console.WriteLine("4 - Delete");
      Console.WriteLine("X - Exit\n");

      string userOption = Console.ReadLine();

      if (userOption.ToUpper() == "X")
        Environment.Exit(0);

      return userOption;
    }
  }
}