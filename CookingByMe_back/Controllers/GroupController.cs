using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookingByMe_back.Controllers
{
    [ApiController]
    [Route("api/groupe")]
    public class GroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        private readonly IGroupRepository _groupRepository;
        private readonly IRecipeRepository _recipeRepository;

        public GroupController(IMapper mapper, IGroupRepository groupRepository, IRecipeRepository recipeRepository)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            _recipeRepository = recipeRepository;
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

                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

                // Add recipe methods
                var groupEntity = _mapper.Map<GroupForCreationDto, Group>(groupForCreation);

                groupEntity.UserId = userId;

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
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var groupsList = await _groupRepository.GetAllGroupsAsync(userId);
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

        [HttpPost("recette")]
        public async Task<IActionResult> AddRecipeToGroup(Group_RecipeForCreationDto groupRecipeForCreation)
        {
            try
            {
                if (groupRecipeForCreation == null)
                {
                    //_logger.LogError("groupRecipeForCreation object sent from client is null.");
                    return BadRequest("groupRecipeForCreation object is null");
                }
                if (!ModelState.IsValid)
                {
                    //_logger.LogError("Invalid groupRecipeForCreation object sent from client.");
                    return BadRequest("Invalid model object");
                }
                Group_Recipe? recipeExist = await _groupRepository.FindRecipeFromGroup(groupRecipeForCreation.GroupId, groupRecipeForCreation.RecipeId);
                if(recipeExist != null)
                {
                    return BadRequest("Recipe already exist in this group");
                }

                // Add recipe methods
                var groupRecipeEntity = _mapper.Map<Group_RecipeForCreationDto, Group_Recipe>(groupRecipeForCreation);
                _groupRepository.AddRecipeAsync(groupRecipeEntity);
                await _groupRepository.SaveAsync();

                var groupRecipeCreated = _mapper.Map<Group_Recipe, Group_RecipeForGroupDto>(groupRecipeEntity);

                return Ok(groupRecipeCreated);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside groupRecipeForCreation action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{groupId}/recette/{recipeId}")]
        public async Task<IActionResult> RemoveRecipeFromGroup(int groupId, int recipeId)
        {
            try
            {
                var CurrentRecipe = await _groupRepository.FindRecipeFromGroup(groupId, recipeId);
                if (CurrentRecipe == null)
                {
                    //_logger.LogError($"Recipe with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                
                _groupRepository.RemoveRecipeFromGroup(CurrentRecipe);
                await _groupRepository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside DeleteRecipeFromGroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("recette/{id}")]
        public async Task<IActionResult> testlitete(int id)
        {
            var test = await _groupRepository.GetAllGroupByRecipeId(id);

            return Ok();
        }
    }
}
