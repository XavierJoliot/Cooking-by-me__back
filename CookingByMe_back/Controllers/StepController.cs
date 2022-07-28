using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.StepModels;
using Microsoft.AspNetCore.Mvc;

namespace CookingByMe_back.Controllers
{
    [ApiController]
    [Route("api/etape")]
    public class StepController : ControllerBase
    {
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly IStepRepository _stepRepository;

        public StepController(IMapper mapper, IStepRepository stepRepository)
        {
            _mapper = mapper;
            _stepRepository = stepRepository;
            //_logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStepByIdAsync(int id)
        {
            var step = await _stepRepository.GetStepByIdAsync(id);
            //_logger.LogInfo($"Returned a step from database.");
            var stepResult = _mapper.Map<Step>(step);
            if (stepResult == null)
            {
                return NotFound();
            }

            return Ok(stepResult);
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStepAsync(int id)
        {
            try
            {
                var step = await _stepRepository.GetStepByIdAsync(id);
                if (step == null)
                {
                    //_logger.LogError($"Step with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _stepRepository.DeleteStep(step);
                await _stepRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside DeleteStep action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStepAsync(int id, StepForUpdateDto step)
        {
            try
            {
                if (step == null)
                {
                    //_logger.LogError("step object sent from client is null.");
                    return BadRequest("step object is null");
                }

                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid step object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var stepEntity = await _stepRepository.GetStepByIdAsync(id);

                _mapper.Map(step, stepEntity);

                if (stepEntity == null)
                {
                    //_logger.LogError($"step with id: {id}, hasn't been found in db.");
                    return NotFound();
                }


                _stepRepository.UpdateStep(stepEntity);
                await _stepRepository.SaveAsync();

                return Ok(stepEntity);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateStepAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
