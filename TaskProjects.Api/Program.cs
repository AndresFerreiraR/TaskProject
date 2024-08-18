using TaskProjects.Persistence;
using TaskProjects.Application;
using TaskProjects.Api.Modules.Injection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddInjection(builder.Configuration);

builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
