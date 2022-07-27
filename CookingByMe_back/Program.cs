using CookingByMe_back.Configuration;
using CookingByMe_back.Core;
using CookingByMe_back.Core.IRepository;
using CookingByMe_back.Core.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;

builder.Services.AddDbContext<CookingByMeContext>(o =>
    o.UseSqlServer(Configuration.GetConnectionString("PrimaryConnexion"))
);


builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Registration of services
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IStepRepository, StepRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
