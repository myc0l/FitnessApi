using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Domain.Repositories;
using FitnessApp.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.API.Persistence.Repositories
{
    public class ExerciseRepository : BaseRepository, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<Excercise>> ListAsync()
        {
            return await _context.Excercises.ToListAsync();
        }

        public async Task AddAsync(Excercise excercise)
        {
            await _context.Excercises.AddAsync(excercise);
        }

        public async Task<Excercise> FindByIdAsync(int id)
        {
            return await _context.Excercises.FindAsync(id);
        }

        public void Update(Excercise excercise)
        {
            _context.Excercises.Update(excercise);
        }

        public void Remove(Excercise excercise)
        {
            _context.Excercises.Remove(excercise);
        }
    }
}