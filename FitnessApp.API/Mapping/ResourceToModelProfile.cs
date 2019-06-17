using AutoMapper;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Resources;

namespace FitnessApp.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateExerciseResource, Excercise>();
            CreateMap<UserResource, User>();
        }
    }
}