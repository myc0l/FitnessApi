using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Domain.Repositories;
using FitnessApp.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<User> Authenticate(string username) //???
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user) //fix password
        {
            await _context.Users.AddAsync(user);
        }

        public void UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }
    }
}