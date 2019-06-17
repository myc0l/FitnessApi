using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Domain.Services.Communication;
using FitnessApp.API.Resources;

namespace FitnessApp.API.Domain.Services
{
    public interface IExcerciseService
    {
        Task<IEnumerable<Excercise>> ListAsync();
        Task<ExerciseResponse> SaveAsync(Excercise excercise);
        Task<ExerciseResponse> UpdateAsync(int id, Excercise excercise);
        Task<ExerciseResponse> DeleteAsync(int id);
    }
}