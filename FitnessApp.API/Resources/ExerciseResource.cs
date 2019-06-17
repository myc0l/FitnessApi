using System;

namespace FitnessApp.API.Resources
{
    
    /*
     *
     *class to be used for mapping resources to the model by the AutoMapper
     * 
     */
    public class ExerciseResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Calories { get; set; }
    }
}