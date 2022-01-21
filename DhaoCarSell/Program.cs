using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DhaoCarSell.Data;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DbConnection"); 
builder.Services.AddDbContext<IdentityContext>(options =>
     options.UseSqlServer(connectionString)); 
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
     options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<IdentityContext>();


builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(
    opts =>
    {

        var suportedCulture = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("fr"),
            new CultureInfo("ru"),
            new CultureInfo("it"),
        };
        opts.DefaultRequestCulture = new RequestCulture("en");
        opts.SupportedCultures = suportedCulture;
        opts.SupportedUICultures = suportedCulture;

    });

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
