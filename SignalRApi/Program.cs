using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using SignalRApi.Model;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();

//api tüketilmesi (consume) için policy ayarlamasý.#86
builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy",builder =>
{
    builder.AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials();
}));

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");//corspolicy kullanýmý #86

app.UseAuthorization();

//hub endpointi verilmesi #86
app.MapHub<VisitorHub>("/VisitorHub");

app.MapControllers();

app.Run();
