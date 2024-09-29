using Microsoft.EntityFrameworkCore;
using todolist_api.Context;
using todolist_api.Mapper;
using todolist_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Permite qualquer origem
               .AllowAnyMethod() // Permite qualquer m�todo (GET, POST, etc.)
               .AllowAnyHeader(); // Permite qualquer cabe�alho
    });
});

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});

builder.Services.AddScoped<ITodoTaskService, TodoTaskService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
