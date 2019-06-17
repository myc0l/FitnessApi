using AutoMapper;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Resources;

namespace FitnessApp.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Excercise, ExerciseResource>();
            CreateMap<User, UserResource>();
        }
    }
}