using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// The primary application startup entry point file configuration block.
/// Sets up the inversion of control service containers and configures the HTTP request execution pipeline.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/// <summary>
/// Registers the Model-View-Controller (MVC) architectural rendering framework engine dependencies.
/// </summary>
builder.Services.AddControllersWithViews();

//Db Connection String
/// <summary>
/// Registers the relational database context and configures it to communicate with SQL Server.
/// Extracts the connection parameters securely from the appsettings json structural file layers.
/// </summary>
builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

/// <summary>
/// Configures a localized volatile memory cache infrastructure block layer.
/// Required by the session framework state components to manage data objects securely.
/// </summary>
builder.Services.AddDistributedMemoryCache();

/// <summary>
/// Initializes and builds session management configurations for web visitors.
/// Defines data lifespans, security scopes, and browser cookie access parameters.
/// </summary>
builder.Services.AddSession(options =>
{
    // Sets the idle timeout limit after which active session data layers are auto-purged from the cache.
    options.IdleTimeout = TimeSpan.FromSeconds(20);

    // Safety flag ensuring session cookies can only be touched by server-side processes (protects against scripts).
    options.Cookie.HttpOnly = true;

    // Marks the session cookies as strictly essential so they load regardless of cookie consent choices.
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/// <summary>
/// Configures the active runtime environment pipeline exceptions handler routing patterns.
/// </summary>
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/// <summary>
/// Forces incoming non-secure HTTP connection traffic strings to securely redirect using SSL/TLS.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Enables the framework routing middleware to evaluate incoming addresses against endpoint parameters.
/// </summary>
app.UseRouting();

/// <summary>
/// Evaluates identity profile authentication restrictions against user security roles.
/// </summary>
app.UseAuthorization();

/// <summary>
/// Injects the active session cookie tracking layer into the web request execution pipeline stack.
/// Must be placed after UseRouting and before MapControllerRoute to capture cookie identifiers.
/// </summary>
app.UseSession();

/// <summary>
/// Maps optimizations for optimized static delivery layers (CSS, JavaScript, images).
/// </summary>
app.MapStaticAssets();

/// <summary>
/// Declares the default URL route blueprint strategy mapping templates for the website controllers.
/// </summary>
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

/// <summary>
/// Launches the configured application host and blocks the calling execution thread until the server shuts down.
/// </summary>
app.Run();
