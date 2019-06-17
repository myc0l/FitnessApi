using FitnessApp.API.Domain.Models;

namespace FitnessApp.API.Domain.Services.Communication
{
    public class ExerciseResponse : BaseResponse
    {
        public Excercise exercise { get; private set; }

        private ExerciseResponse(bool success, string message, Excercise exercise) : base(success, message)
        {
            this.exercise = exercise;
        }

        public ExerciseResponse(Excercise exercise) : this(true, string.Empty, exercise)
        {
            
        }

        public ExerciseResponse(string message) : this(false, message, null)
        {
        }
    }
}