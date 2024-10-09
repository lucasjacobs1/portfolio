using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using BusinessLayer.Interfaces;
using BusinessLayer.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Notification.API;
using PersistenceLayer.Entities;
using PersistenceLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationMembershipRepository, NotificationMembershipRepository>();
builder.Services.AddScoped<INotificationLogic, NotificationLogic>();
builder.Services.AddScoped<IMessagingLogic, MessagingLogic>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration;
var credential = new ClientSecretCredential(config["AzureKeyVault:TenantId"], config["AzureKeyVault:ClientId"], config["AzureKeyVault:ClientSecret"]);
var client = new SecretClient(new Uri($"https://{config["AzureKeyVault:VaultName"]}.vault.azure.net/"), credential);
builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

var connectionString = config["NOTIFICATION-DB-IMAGE"];
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//NOTE: applies the tables in remote
if (!app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}
//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
