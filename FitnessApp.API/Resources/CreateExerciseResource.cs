using System.ComponentModel.DataAnnotations;

namespace FitnessApp.API.Resources


/*
 *
 * Resource class creates a resource that has the only necessary fields that will be returned by API endpoint to create
 * an exercise
 * 
 */
{
    public class CreateExerciseResource
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        
        [Required]
        public int Duration { get; set; }
        
        [Required]
        public int Calories { get; set; }
    }
}