var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app
    .MapGet("/hello", () => "Hello I'm running inside a docker image in WSL")
    .WithName("GetHello")
    .WithOpenApi();

app
    .MapGet("/helloMachine1", () => "Hello I was generated from the machine setup 1")
    .WithName("GetMachine1")
    .WithOpenApi();

app.Run();
