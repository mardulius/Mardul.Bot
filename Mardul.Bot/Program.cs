using Data;
using Data.Repositories;
using Mardul.Bot.Commands;
using Mardul.Bot.Services.BotService;
using Mardul.Bot.Services.CommandService;
using Mardul.Bot.Services.UserService;
using Mardul.Bot.Services.YandexAuthService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<BotContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("BotDatabase")));
builder.Services.AddSingleton<BotService>();
builder.Services.AddTransient<ICommandService, CommandService>();
builder.Services.AddTransient<IBaseCommand, StartCommand>();
builder.Services.AddTransient<IBaseCommand, RegistrationCommand>();
builder.Services.AddTransient<IBaseCommand, AuthYandexCommand>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IYandexAuthService, YandexAuthService>();
builder.Services.AddTransient<IUserService, UserService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "Hello World!");

app.UseAuthorization();
app.MapControllers();
app.Services.GetService<BotService>().GetBotAsync().Wait();
app.Run();
