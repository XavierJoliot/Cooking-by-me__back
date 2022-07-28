using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;
using Microsoft.AspNetCore.Mvc;

namespace CookingByMe_back.Controllers
{
    [ApiController]
    [Route("api/groupe")]
    public class GroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly IGroupRepository _groupRepository;

        public GroupController(IMapper mapper, IGroupRepository groupRepository)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            //_logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroupAsync(GroupForCreationDto groupForCreation)
        {
            try
            {
                if (groupForCreation == null)
                {
                    //_logger.LogError("GroupForCreation object sent from client is null.");
                    return BadRequest("GroupForCreation object is null");
                }
                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid GroupForCreation object sent from client.");
                    return BadRequest("Invalid model object");
                }

                // Add recipe methods
                var groupEntity = _mapper.Map<GroupForCreationDto, Group>(groupForCreation);
                _groupRepository.CreateGroup(groupEntity);
                await _groupRepository.SaveAsync();


                var createdGroup = _mapper.Map<Group, GroupDto>(groupEntity);

                return Ok(createdGroup);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside GroupForCreation action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroupsAsync()
        {
            var groupsList = await _groupRepository.GetAllGroupsAsync();
            //_logger.LogInfo($"Returned all groups from database.");
            var groupsResult = _mapper.Map<List<Group>>(groupsList);
            return Ok(groupsResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupByIdAsync(int id)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);
            //_logger.LogInfo($"Returned a group from database.");
            var groupResult = _mapper.Map<Group>(group);
            if (groupResult == null)
            {
                return NotFound();
            }

            return Ok(groupResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupAsync(int id)
        {
            try
            {
                var group = await _groupRepository.GetGroupByIdAsync(id);
                if (group == null)
                {
                    //_logger.LogError($"Group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _groupRepository.DeleteGroup(group);
                await _groupRepository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside DeleteGroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupAsync(int id, GroupForUpdateDto group)
        {
            try
            {
                if (group == null)
                {
                    //_logger.LogError("Group object sent from client is null.");
                    return BadRequest("Group object is null");
                }

                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid group object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var groupEntity = await _groupRepository.GetGroupByIdAsync(id);

                _mapper.Map(group, groupEntity);

                if (groupEntity == null)
                {
                    //_logger.LogError($"Group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }


                _groupRepository.UpdateGroup(groupEntity);
                await _groupRepository.SaveAsync();

                return Ok(groupEntity);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside UpdateGroupAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
