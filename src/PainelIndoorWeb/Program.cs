using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PainelIndoor.Infra.Data.Contexts;
using PainelIndoorWeb.Configurations;
using PainelIndoorWeb.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddJsonFile($"appsettings.overrides.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<ApplicationDbContext>(c =>
                c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => {
                    options.CommandTimeout(180);
                }));

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 134217728;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adicionando o signalR como um serviço da aplicação
builder.Services.AddSignalR();

builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
builder.Services.AddDIConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//para acessar os arquivos estáticos (js, css, images)
//learn more: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-8.0
app.UseStaticFiles();

app.UseRouting(); //ok

app.UseAuthentication(); //ok
app.UseAuthorization(); //ok

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "uploads", "videos"))
    //RequestPath = "/videos"
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Inicio}/{id?}");

app.MapHub<HubSignalR>("/ComandosRemotos");

app.Run();
