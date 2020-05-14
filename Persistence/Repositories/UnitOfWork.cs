using System.Threading.Tasks;
using Livecoding.API.Domain.Repositories;
using Livecoding.API.Persistence.Contexts;

namespace Livecoding.API.Persistence.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
      _context = context;
    }

    public async Task CompleteAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}