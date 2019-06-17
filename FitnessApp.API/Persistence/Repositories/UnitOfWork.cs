using System.Threading.Tasks;
using FitnessApp.API.Domain.Repositories;
using FitnessApp.API.Persistence.Contexts;

namespace FitnessApp.API.Persistence.Repositories
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