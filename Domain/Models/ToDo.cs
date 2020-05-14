using System;
using System.ComponentModel.DataAnnotations;

namespace Livecoding.API.Domain.Models
{
  public class ToDo
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
    public float Complete { get; set; }
  }
}