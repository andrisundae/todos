using AutoMapper;
using Livecoding.API.Domain.Models;
using Livecoding.API.Resources;

namespace Livecoding.API.Mapping
{
  public class ResourceToModelProfile : Profile
  {
    public ResourceToModelProfile()
    {
      CreateMap<SaveToDoResource, ToDo>();
    }
  }
}