using AutoMapper;
using Livecoding.API.Domain.Models;
using Livecoding.API.Resources;

namespace Livecoding.API.Mapping
{
  public class ModelToResourceProfile : Profile
  {
    public ModelToResourceProfile()
    {
      CreateMap<ToDo, ToDoResource>();
    }
  }
}