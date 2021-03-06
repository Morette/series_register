using System;
using Entities;
using Enums;

namespace Model
{
  public class Serie : BaseEntity
  {
    public Genre Genre { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }

    public Serie(Genre genre, string title, string description, int year)
    {
      this.Id = Guid.NewGuid();
      this.Genre = genre;
      this.Title = title;
      this.Description = description;
      this.Year = year;
    }

    public string SearchTitle()
    {
      return this.Title;
    }

    public override string ToString()
    {
      string retorno = string.Empty;
      retorno += $"Id: {this.Id}\n";
      retorno += $"Genre: {this.Genre} \n";
      retorno += $"Title: {this.Title} \n";
      retorno += $"Description: {this.Description} \n";
      retorno += $"Year: {this.Year} \n";

      return retorno;
    }
  }
}