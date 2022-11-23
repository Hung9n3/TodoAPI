using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Database;
using TodoApi.DTOs.Mapping;
using TodoApi.Helpers.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer
                                                (builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddTransient<WorkDataHelpers>();


var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:7094")
              .AllowCredentials();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo.Api v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
