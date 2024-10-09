using AspNetCoreHero.ToastNotification;
using DataLayer;
using LogicLayer;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = new PathString("/LoginPage");
        options.AccessDeniedPath = new PathString("/Index");
    });

builder.Services.AddSingleton<IUserService, UserManagement>();
builder.Services.AddSingleton<UserAdmin>();

builder.Services.AddSingleton<ISportService, SportManagement>();
builder.Services.AddSingleton<SportAdmin>();

builder.Services.AddSingleton<UserHelper>();

builder.Services.AddSingleton<ILoginService, UserData>();
builder.Services.AddSingleton<LoginAdmin>();

builder.Services.AddSingleton<ITournamentService, TournamentManagement>();
builder.Services.AddSingleton<TournamentAdmin>();

builder.Services.AddSingleton<IMatchService, MatchManagement>();
builder.Services.AddSingleton<MatchAdmin>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePages();
app.UseStatusCodePagesWithRedirects("/Index");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});
app.MapRazorPages();

app.Run();
