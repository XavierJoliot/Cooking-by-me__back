using CookingByMe_back.Models.Group;
using CookingByMe_back.Models.Ingredient;
using CookingByMe_back.Models.Recipe;
using CookingByMe_back.Models.Step;
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
