using System.Collections.Generic;
using System.Threading.Tasks;
using Livecoding.API.Domain.Models;

namespace Livecoding.API.Domain.Repositories
{
  public interface IToDoRepository
  {
    Task<IEnumerable<ToDo>> ListAsync();
    Task AddAsync(ToDo todo);
    Task<ToDo> FindByIdAsync(int id);
    void Update(ToDo todo);
    void Remove(ToDo todo);
  }
}