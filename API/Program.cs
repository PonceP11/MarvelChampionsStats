using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain;
using Infraestructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options => options.UseLazyLoadingProxies().UseSqlite(
    "Data source=db.db"
));
/*builder.Services.AddDbContext<HeroDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));
builder.Services.AddDbContext<AspectDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));
builder.Services.AddDbContext<DeckDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));
builder.Services.AddDbContext<ModularEncounterDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));
builder.Services.AddDbContext<DifficultyDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));
builder.Services.AddDbContext<ScenarioDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));
/*builder.Services.AddDbContext<ContentDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));
builder.Services.AddDbContext<GameDBContext>(options => options.UseSqlite(
    "Data source=db.db"
));*/

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                     policy =>
                     {
                        //policy.WithOrigins("*");
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                        policy.AllowAnyOrigin();
                     });

});

builder.Services.AddScoped<IDeckService, DeckService>();
builder.Services.AddScoped<IDeckRepository, DeckRepository>();
builder.Services.AddScoped<IAspectService, AspectService>();
builder.Services.AddScoped<IAspectRepository, AspectRepository>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IModularEncounterService, ModularEncounterService>();
builder.Services.AddScoped<IModularEncounterRepository, ModularEncounterRepository>();
builder.Services.AddScoped<IDifficultyService, DifficultyService>();
builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();
builder.Services.AddScoped<IScenarioService, ScenarioService>();
builder.Services.AddScoped<IScenarioRepository, ScenarioRepository>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

var config = new MapperConfiguration(conf =>
{
    conf.CreateMap<HeroDTO, Hero>();
    conf.CreateMap<AspectDTO, Aspect>();
    conf.CreateMap<DeckDTO, Deck>();
    conf.CreateMap<UserDTO, User>();
    conf.CreateMap<ModularEncounterDTO, ModularEncounter>();
    conf.CreateMap<ScenarioDTO, Scenario>();
    conf.CreateMap<ContentDTO, Content>();
    conf.CreateMap<DifficultyDTO, Difficulty>();
    conf.CreateMap<GameDTO, Game>();
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();