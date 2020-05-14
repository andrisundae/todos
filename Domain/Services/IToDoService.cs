using System.Collections.Generic;
using System.Threading.Tasks;
using Livecoding.API.Domain.Models;
using Livecoding.API.Domain.Services.Communication;

namespace Livecoding.API.Domain.Services
{
  public interface IToDoService
  {
    Task<IEnumerable<ToDo>> ListAsync();
    Task<ToDoResponse> SaveAsync(ToDo todo);
    Task<ToDoResponse> UpdateAsync(int id, ToDo todo);
    Task<ToDoResponse> DeleteAsync(int id);
    Task<ToDoResponse> GetToDoById(int id);
  }
}