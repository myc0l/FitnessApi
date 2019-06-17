using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.API.Domain.Models;
using FitnessApp.API.Domain.Services;
using FitnessApp.API.Resources;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.API.Extensions;

namespace FitnessApp.API.Controllers
{
    [Route("/api/[controller]")]
    public class ExercisesController : Controller
    {
        private readonly IExcerciseService _excerciseService;
        private IMapper _mapper;

        public ExercisesController(IExcerciseService excerciseService, IMapper mapper)
        {
            _excerciseService = excerciseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CreateExerciseResource>> GetAllAsync()
        {
            var exercises = await _excerciseService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Excercise>, IEnumerable<CreateExerciseResource>>(exercises);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateExerciseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var exercise = _mapper.Map<CreateExerciseResource, Excercise>(resource);
            var result = await _excerciseService.SaveAsync(exercise);

            if (!result.Success)
                return BadRequest(result.Message);

            var exerciseResource = _mapper.Map<Excercise, ExerciseResource>(result.exercise);
            return Ok(exerciseResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateExerciseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var exercise = _mapper.Map<CreateExerciseResource, Excercise>(resource);
            var result = await _excerciseService.UpdateAsync(id,exercise);

            if (!result.Success)
                return BadRequest(result.Message);

            var exerciseResource = _mapper.Map<Excercise, ExerciseResource>(result.exercise);
            return Ok(exerciseResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _excerciseService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Excercise, ExerciseResource>(result.exercise);
            return Ok(categoryResource);
        }
    }
}