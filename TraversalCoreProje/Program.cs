using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Wordprocessing;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
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
    .AddErrorDescriber<CustomIdentityValidator>()
    .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)//�ifre Yenileme Linki ��in Token Register.
    .AddEntityFrameworkStores<Context>();


builder.Services.AddHttpClient();//visitorapicontroller i�inde kullan�lan httpclient icin ders 70

builder.Services.ContainerDependencies();//ders 56 ef core bag�ml�l�g�n�n kald�r�lmas�.



builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
    
});
//D�L DESTE��
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});
//dildeste�i
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

//MAPLEME
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.CustomerValidator();//extension
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/SignIn";
    opt.AccessDeniedPath = new PathString("/Default/Index");//yetkilendirilmiş sayfaya erişmeye çalışan yetkisiz kullanıcıları “/Default/Index” adresine yönlendirmekteyiz.
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

//dil deste�i 
var supportedCultures = new[] { "en", "fr", "es", "tr", "de" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[3])
    .AddSupportedCultures(supportedCultures)//backend taraf�na ekle?
    .AddSupportedUICultures(supportedCultures);//frontend taraf�na ekle? 
app.UseRequestLocalization(localizationOptions);

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
