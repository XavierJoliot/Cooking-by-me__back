using AutoMapper;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookingByMe_back.Controllers
{
    [ApiController]
    [Authorize]
    [EnableCors]
    [Route("api/groupe")]
    public class GroupController : MainController
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
        public async Task<IActionResult> CreateGroupAsync([FromForm] GroupForCreationDto groupForCreation)
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

                if (groupForCreation.ImagePath != null)
                {
                    AddImage(groupForCreation.ImagePath);
                    groupEntity.ImagePath = groupForCreation.ImagePath.FileName;
                }

                groupEntity.UserId = userId;

                _groupRepository.CreateGroup(groupEntity);
                await _groupRepository.SaveAsync();


                var createdGroup = _mapper.Map<Group, GroupDto>(groupEntity);

                return Ok(createdGroup);
            }
            catch (Exception)
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
            if (group == null)
            {
                return NotFound();
            }

            GroupDto CurrentGroup = _mapper.Map<Group, GroupDto>(group);

            return Ok(CurrentGroup);
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
            catch (Exception)
            {
                //_logger.LogError($"Something went wrong inside DeleteGroup action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupAsync(int id, [FromForm] GroupForUpdateDto group)
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

                if (groupEntity == null)
                {
                    //_logger.LogError($"Group with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                string? currentImage = groupEntity!.ImagePath;

                _mapper.Map(group, groupEntity);

                if (group.ImagePath != null && group.ImagePath.FileName != currentImage)
                {
                    AddImage(group.ImagePath);
                    groupEntity.ImagePath = group.ImagePath.FileName;
                }
                else
                {
                    groupEntity.ImagePath = currentImage;
                }

                if (group.RecipeIds != null)
                {
                    foreach (var recipeId in group.RecipeIds!)
                    {
                        if (groupEntity.Group_Recipe!.Find(elmt => elmt.GroupId == recipeId) == null)
                        {
                            Group_Recipe groupRecipe = new Group_Recipe()
                            {
                                GroupId = groupEntity.Id,
                                RecipeId = recipeId,
                            };

                            groupEntity.Group_Recipe!.Add(groupRecipe);
                            await _groupRepository.SaveAsync();
                        }
                    }
                }

                _groupRepository.UpdateGroup(groupEntity);
                await _groupRepository.SaveAsync();

                return Ok(groupEntity);
            }
            catch (Exception)
            {
                //_logger.LogError($"Something went wrong inside UpdateGroupAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
