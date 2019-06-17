using System;
using System.Collections.Generic;

namespace FitnessApp.API.Domain.Models
{
    public class Excercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Calories { get; set; }
     
    }
}