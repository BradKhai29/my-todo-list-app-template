using Application.Handlers.Base;
using Models.Application.Handlers.Auth;
using Models.Application.Handlers.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var serviceProvider = app.Services;

AppHandlerRequestRegistry.SetUp(serviceProvider);
var request = new UserLoginRequest();
var response = await request.HandleAsync(default);
var realResponse = request.GetResponse(response);

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
