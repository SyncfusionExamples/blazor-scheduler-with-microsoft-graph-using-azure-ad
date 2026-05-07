using BlazorSchedulerApp.Components;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Syncfusion.Blazor;
using Microsoft.Extensions.Caching.Distributed;
using BlazorSchedulerApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Razor / Blazor
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler(); 

builder.Services.AddCascadingAuthenticationState();

// Simple file-based distributed cache for local/dev token cache persistence.
// This allows .AddDistributedTokenCaches() to persist MSAL tokens across restarts
// without an external cache (Redis/SQL). For production prefer Redis/SQL.
builder.Services.AddSingleton<IDistributedCache>(sp =>
    new FileDistributedCache(Path.Combine(AppContext.BaseDirectory, "msal_cache")));

builder.Services
    .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
    // ↓↓↓ This line registers ITokenAcquisition for DI
    .EnableTokenAcquisitionToCallDownstreamApi(
         new[] { "Calendars.Read", "Calendars.ReadWrite" })
    // Choose one cache provider:
    .AddDistributedTokenCaches();  

// UI pages (/MicrosoftIdentity/Account/SignIn etc.)
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpContextAccessor();

// HttpClient
builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
