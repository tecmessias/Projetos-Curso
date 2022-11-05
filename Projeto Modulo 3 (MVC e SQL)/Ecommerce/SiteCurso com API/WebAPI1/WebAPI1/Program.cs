using WebAPI1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
 {
     builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
 }));


var app = builder.Build();


app.UseCors("corsapp");
// Configure the HTTP request pipeline.
app.RegisterAPIs();

app.Run();
