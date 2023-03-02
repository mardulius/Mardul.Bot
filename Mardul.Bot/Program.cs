using Mardul.Bot.Commands;
using Mardul.Bot.Services.BotService;
using Mardul.Bot.Services.CommandService;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<BotService>();
builder.Services.AddSingleton<ICommandService, CommandService>();
builder.Services.AddSingleton<IBaseCommand, StartCommand>();
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
