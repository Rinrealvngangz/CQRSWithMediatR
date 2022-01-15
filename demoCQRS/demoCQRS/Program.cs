using System.Reflection;
using demoCQRS.PipelineBehaviors;
using demoCQRS.Repository;
using demoCQRS.Repository.Cached;
using demoCQRS.Validation;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureServices((_, services) =>
{
    services.AddSingleton<IRepositoryOrder, RepositoryOrder>();
    services.Decorate<IRepositoryOrder, CachedCustomerRepository>();
    services.AddMediatR(Assembly.GetExecutingAssembly());
    services.AddValidatorsFromAssemblyContaining(typeof(CreateOrderValidation));
    services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
});
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