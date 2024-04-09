var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .RegisterAppOptions()
    .RegisterPersistenceLayer(builder.Environment)
    .RegisterPresentationLayer();

var app = builder.Build();

app
    .AddPresentationLayer()
    .UseHttpsRedirection();

app.Run();
