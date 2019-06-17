using System.Threading.Tasks;

namespace FitnessApp.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}