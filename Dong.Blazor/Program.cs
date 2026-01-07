using Dong.Application.Calculator;
using Dong.Application.Crud;
using Dong.Application.Identity;
using Dong.Blazor.Components;
using Dong.Infrastructure.Calculator;
using Dong.Infrastructure.Crud;
using Dong.Infrastructure.dbContext;
using Dong.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
// Application Services
builder.Services.AddScoped<IShareCalculator, ShareCalculator>();
builder.Services.AddScoped<IDebitCreditCalculator, DebitCreditCalculator>();
builder.Services.AddScoped<ICrud, Crud>();
builder.Services.AddScoped<IIdentity, Identity>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
