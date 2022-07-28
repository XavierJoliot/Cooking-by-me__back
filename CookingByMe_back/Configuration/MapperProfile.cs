using AutoMapper;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.RecipeModels;
using CookingByMe_back.Models.StepModels;

namespace CookingByMe_back.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeForCreationDto, Recipe>();
            CreateMap<RecipeForUpdateDto, Recipe>();
            CreateMap<RecipeForGroupDto, Recipe>();
            CreateMap<Recipe, RecipeForGroupDto>();

            CreateMap<Step, StepDto>();
            CreateMap<StepForCreationDto, Step>();
            CreateMap<StepForUpdateDto, Step>();

            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientForCreationDto, Ingredient>();
            CreateMap<IngredientForUpdateDto, Ingredient>();

            CreateMap<Group, GroupDto>();
            CreateMap<GroupForCreationDto, Group>();
            CreateMap<GroupForUpdateDto, Group>();
        }
    }
}
