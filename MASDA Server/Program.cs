// Entry point for MASDA Server

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddHostedService<TradeAndOrderbookService>();

var app = builder.Build();

app.UseWebSockets();
app.MapHub<ConnectionHub>("/connectionHub");

app.Run();