global using Microsoft.EntityFrameworkCore;
global using GraphQL.API.Infrastructure.DBContext;
global using GraphQL.API.Repositories;
using GraphQL.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITechEventRepository, TechEventRepository>();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();
builder.Services.AddDbContext<TechEventDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDBConnection"));
});
builder.Services.AddTransient<ITechEventRepository, TechEventRepository>();
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

app.MapGraphQL("/graphql");

app.Run();
