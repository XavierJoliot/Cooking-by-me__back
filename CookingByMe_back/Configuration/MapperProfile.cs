using AutoMapper;
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

            CreateMap<Step, StepDto>();
            CreateMap<StepForCreationDto, Step>();

            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientForCreationDto, Ingredient>();
        }
    }
}
