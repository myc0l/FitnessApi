using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Domain.Repositories;
using FitnessApp.API.Domain.Services;
using FitnessApp.API.Domain.Services.Communication;
using FitnessApp.API.Resources;

namespace FitnessApp.API.Services
{
    public class ExerciseService : IExcerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExerciseService(IExerciseRepository exerciseRepository, IUnitOfWork unitOfWork)
        {
            _exerciseRepository = exerciseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Excercise>> ListAsync()
        {
            return await _exerciseRepository.ListAsync();
        }

        public async Task<ExerciseResponse> SaveAsync(Excercise excercise)
        {
            try
            {
                await _exerciseRepository.AddAsync(excercise);
                await _unitOfWork.CompleteAsync();
                
                return new ExerciseResponse(excercise);
            }
            catch (Exception e)
            {
              return new ExerciseResponse($"An error occured when saving the exercise: {e.Message}");
            }
        }

        public async Task<ExerciseResponse> UpdateAsync(int id, Excercise excercise)
        {
            var existingExercise = await _exerciseRepository.FindByIdAsync(id);
            if(existingExercise == null)
                return new ExerciseResponse("Exercise not found ufunge");

            existingExercise.Name = excercise.Name;
            existingExercise.Duration = excercise.Duration;
            existingExercise.Calories = excercise.Calories;
            
            try
            {
                _exerciseRepository.Update(existingExercise);
                await _unitOfWork.CompleteAsync();
                
                return new ExerciseResponse(existingExercise);
            }
            catch (Exception e)
            {
                return new ExerciseResponse($"An error occured while trying to update Exercise: {e.Message}");
            }
        }

        public async Task<ExerciseResponse> DeleteAsync(int id)
        {
            var existingExercise = await _exerciseRepository.FindByIdAsync(id);
            
            if(existingExercise == null)
                return new ExerciseResponse("Exercise not found");

            try
            {
                _exerciseRepository.Remove(existingExercise);
                await _unitOfWork.CompleteAsync();
                
                return new ExerciseResponse(existingExercise);
            }
            catch (Exception e)
            {
              return new ExerciseResponse($"An error occured trying to delete exercise : {e.Message}");
            }
        }
    }
}