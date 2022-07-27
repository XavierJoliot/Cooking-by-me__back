using CookingByMe_back.Models.GroupModels;
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
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Step> Step { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var recipe = modelBuilder.Entity<Recipe>();
            var group = modelBuilder.Entity<Group>();
            var ingredient = modelBuilder.Entity<Ingredient>();
            var step = modelBuilder.Entity<Step>();


            recipe.HasKey(r => r.Id);
            recipe.Property(r => r.CreatedAt).HasDefaultValueSql("getdate()");
            recipe.HasMany(r => r.StepList).WithOne();
            recipe.HasMany(r => r.IngredientList).WithOne();


            group.HasKey(g => g.Id);
            group.Property(g => g.CreatedAt).HasDefaultValueSql("getdate()");
            group.HasMany(g => g.RecipesList).WithMany(r => r.GroupList);

            ingredient.HasKey(i => i.Id);
            ingredient.Property(i => i.CreatedAt).HasDefaultValueSql("getdate()");

            step.HasKey(s => s.Id);
            step.Property(s => s.CreatedAt).HasDefaultValueSql("getdate()");
        }
    }
}
