using Interfaces;
using Services;

namespace Views
{
  public abstract class AbstractView : IView
  {
    protected SeriesService _service;

    public AbstractView(SeriesService service)
    {
      this._service = service;
    }

    public abstract void AddView();
    public abstract void DeleteView();
    public abstract void UpdateView();
  }
}