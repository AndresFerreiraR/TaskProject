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

string myPolicy = "PolicyApiEcommerce";

builder.Services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.AllowAnyOrigin()
                                                                               .AllowAnyHeader()
                                                                               .AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(myPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
