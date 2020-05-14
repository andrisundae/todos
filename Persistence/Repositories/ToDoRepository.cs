using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Livecoding.API.Domain.Models;
using Livecoding.API.Domain.Repositories;
using Livecoding.API.Persistence.Contexts;

namespace Livecoding.API.Persistence.Repositories
{
  public class ToDoRepository : BaseRepository, IToDoRepository
  {
    public ToDoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ToDo>> ListAsync()
    {
      return await _context.ToDos.ToListAsync();
    }

    public async Task AddAsync(ToDo todo)
    {
      await _context.ToDos.AddAsync(todo);
    }

    public async Task<ToDo> FindByIdAsync(int id)
    {
      return await _context.ToDos.FindAsync(id);
    }

    public void Update(ToDo category)
    {
      _context.ToDos.Update(category);
    }

    public void Remove(ToDo category)
    {
      _context.ToDos.Remove(category);
    }
  }
}