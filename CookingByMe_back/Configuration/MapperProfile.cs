using AutoMapper;
using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;
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
            CreateMap<RecipeDto, Recipe>();
            CreateMap<RecipeForCreationDto, Recipe>();
            CreateMap<RecipeForUpdateDto, Recipe>();

            CreateMap<Step, StepDto>();
            CreateMap<StepForCreationDto, Step>();
            CreateMap<StepForCreationFromRecipeDto, Step>();
            CreateMap<StepForUpdateDto, Step>();
            CreateMap<StepForUpdateFromRecipeDto, Step>();

            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientForCreationDto, Ingredient>();
            CreateMap<IngredientForCreationFromRecipeDto, Ingredient>();
            CreateMap<IngredientForUpdateDto, Ingredient>();
            CreateMap<IngredientForUpdateFromRecipeDto, Ingredient>();

            CreateMap<Group, GroupDto>();
            CreateMap<GroupForCreationDto, Group>();
            CreateMap<GroupForUpdateDto, Group>();

            CreateMap<Group_Recipe, Group_RecipeForGroupDto>();
            CreateMap<Group_Recipe, Group_RecipeForRecipeDto>();
            CreateMap<Group_RecipeForCreationDto, Group_Recipe>();
        }
    }
}
