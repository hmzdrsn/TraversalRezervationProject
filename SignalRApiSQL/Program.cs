using SignalRApiSQL.DAL;
using SignalRApiSQL.Hubs;
using SignalRApiSQL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();

//api tüketilmesi (consume) için policy ayarlamasý.#86
builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", builder =>
{
	builder.AllowAnyHeader()
	.AllowAnyMethod()
	.SetIsOriginAllowed((host) => true)
	.AllowCredentials();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseAuthorization();
//hub endpointi verilmesi #86
app.MapHub<VisitorHub>("/VisitorHub");
app.MapControllers();

app.Run();
