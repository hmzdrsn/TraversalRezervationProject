using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//ptions => options.SignIn.RequireConfirmedEmail = false


builder.Services.AddScoped<GetAllDestinationQueryHandler>();//CQRS 
builder.Services.AddScoped<GetDestinationByIdHandler>();//CQRS 
builder.Services.AddScoped<CreateDestinationCommandHandler>();//CQRS 
builder.Services.AddScoped<DeleteDestinationCommandHandler>();//CQRS 

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddLogging(
    x=>{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
        var path = Directory.GetCurrentDirectory();
        x.AddFile($"{path}\\Logs\\Log1.txt");
    }
    );


builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();


builder.Services.AddHttpClient();//visitorapicontroller içinde kullanýlan httpclient icin ders 70

builder.Services.ContainerDependencies();//ders 56 ef core bagýmlýlýgýnýn kaldýrýlmasý.



builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
    
});

//MAPLEME
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.CustomerValidator();//extension
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/SignIn";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



//Area Member
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
//Area Admin
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();
