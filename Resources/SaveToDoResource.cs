using System.ComponentModel.DataAnnotations;

namespace Livecoding.API.Resources
{
  public class SaveToDoResource
  {
    [Required]
    public string ExpiryDate { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(50)]
    public string Description { get; set; }
    public float Complete { get; set; }
  }
}