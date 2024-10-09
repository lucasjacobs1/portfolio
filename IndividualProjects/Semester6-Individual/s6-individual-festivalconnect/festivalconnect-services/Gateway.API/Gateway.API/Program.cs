using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Kubernetes;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration)
.AddConsul()
.AddKubernetes();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddHealthChecks();

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
         builder =>
         {
             builder.WithOrigins("http://localhost:4000")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
         });

});*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
         builder =>
         {
             builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
         });

});

var config = builder.Configuration;

var credential = new ClientSecretCredential(config["AzureKeyVault:TenantId"], config["AzureKeyVault:ClientId"], config["AzureKeyVault:ClientSecret"]);
var client = new SecretClient(new Uri($"https://{config["AzureKeyVault:VaultName"]}.vault.azure.net/"), credential);
builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

var jwtkey = config["JWT-KEY"];

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtkey))
        };
    });


var app = builder.Build();



app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigins");
app.UseAuthorization();

await app.UseOcelot();


app.MapReverseProxy();

app.Run();
