using CookingByMe_back.Models.GroupModels;
using CookingByMe_back.Models.GroupRecipeModels;
using CookingByMe_back.Models.IngredientModels;
using CookingByMe_back.Models.RecipeModels;
using CookingByMe_back.Models.StepModels;
using Microsoft.EntityFrameworkCore;

namespace CookingByMe_back.Core
{
    public class CookingByMeContext : DbContext
    {
        public CookingByMeContext(DbContextOptions<CookingByMeContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Group_Recipe> Group_Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Step> Step { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var recipe = modelBuilder.Entity<Recipe>();
            var group = modelBuilder.Entity<Group>();
            var groupRecipe = modelBuilder.Entity<Group_Recipe>();
            var ingredient = modelBuilder.Entity<Ingredient>();
            var step = modelBuilder.Entity<Step>();


            recipe.HasKey(r => r.Id);
            recipe.Property(r => r.CreatedAt).HasDefaultValueSql("getdate()");
            recipe.Property(r => r.IsPublic).HasDefaultValue(false);
            recipe.HasMany(r => r.StepsList).WithOne(s => s.Recipe).HasForeignKey(s => s.RecipeId).OnDelete(DeleteBehavior.Cascade);
            recipe.HasMany(r => r.IngredientsList).WithOne(i => i.Recipe).HasForeignKey(i => i.RecipeId).OnDelete(DeleteBehavior.Cascade);

            group.HasKey(g => g.Id);
            group.Property(g => g.CreatedAt).HasDefaultValueSql("getdate()");

            groupRecipe.HasKey(gr => gr.Id);
            groupRecipe.HasOne(gr => gr.Recipe).WithMany(r => r.Group_Recipe).HasForeignKey(gr => gr.RecipeId);
            groupRecipe.HasOne(gr => gr.Group).WithMany(g => g.Group_Recipe).HasForeignKey(gr => gr.GroupId);

            ingredient.HasKey(i => i.Id);
            ingredient.Property(i => i.CreatedAt).HasDefaultValueSql("getdate()");

            step.HasKey(s => s.Id);
            step.Property(s => s.CreatedAt).HasDefaultValueSql("getdate()");
        }
    }
}
