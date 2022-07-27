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
                var createdOwner = _mapper.Map<Step, StepDto>(stepEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside CreateStep action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
