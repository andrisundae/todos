using System.Threading.Tasks;

namespace Livecoding.API.Domain.Repositories
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}