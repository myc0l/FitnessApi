using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.API.Domain.Models;

namespace FitnessApp.API.Domain.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Excercise>> ListAsync();
        Task AddAsync(Excercise excercise);
        Task<Excercise> FindByIdAsync(int id);
        void Update(Excercise excercise);
        void Remove(Excercise excercise);
    }
}