using System;
using System.ComponentModel.DataAnnotations;

namespace Livecoding.API.Resources
{
  public class ToDoResource
  {
    //Column Id type int
    public int Id { get; set; }
    //Column ExpiryDate type DateTime
    [DataType(DataType.DateTime)]
    public DateTime ExpiryDate { get; set; }
    //Column Title type string
    public string Title { get; set; }
    //Column Description
    public string Description { get; set; }
    public decimal complete { get; set; }
  }
}