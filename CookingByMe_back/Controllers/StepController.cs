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

        [HttpPost]
        public async Task<IActionResult> CreateStepAsync(StepForCreationDto stepForCreation)
        {
            try
            {
                if (stepForCreation == null)
                {
                    //_logger.LogError("StepForCreation object sent from client is null.");
                    return BadRequest("StepForCreation object is null");
                }
                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var stepEntity = _mapper.Map<StepForCreationDto, Step>(stepForCreation);

                _stepRepository.CreateStep(stepEntity);

                await _stepRepository.SaveAsync();

                var createdStep = _mapper.Map<Step, StepDto>(stepEntity);

                return Ok(createdStep);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside CreateStep action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStepAsync(int id)
        {
            try
            {
                var step = await _stepRepository.GetStepByIdAsync(id);
                if (step == null)
                {
                    //_logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _stepRepository.DeleteStep(step);
                await _stepRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
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

                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateStepAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
