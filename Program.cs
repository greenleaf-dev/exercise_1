/// <summary>
/// Entry point for the MTTApp (Multi-Tool Test Application) Razor Pages web application.
/// This application demonstrates a modern ASP.NET Core web application with Razor Pages,
/// integration with Azure OpenAI services, and comprehensive test coverage.
/// </summary>

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// SERVICES CONFIGURATION SECTION
/// Registers required services for the application to function.
/// </summary>

// Add Razor Pages support to the service container.
// Razor Pages is a page-focused framework that makes building web UI easier and more productive.
builder.Services.AddRazorPages();

/// <summary>
/// APPLICATION BUILDER SECTION
/// Builds the application configuration and returns a WebApplication instance.
/// </summary>
var app = builder.Build();

/// <summary>
/// MIDDLEWARE PIPELINE CONFIGURATION SECTION
/// Configures the HTTP request processing pipeline.
/// The order of middleware is important as each middleware processes the request and passes it to the next.
/// </summary>

// Configure error handling based on the application environment.
// In non-development environments, use a friendly error page.
// In development environments, use the detailed exception page (handled by ASP.NET Core framework).
if (!app.Environment.IsDevelopment())
{
    // Redirect unhandled exceptions to the /Error page
    app.UseExceptionHandler("/Error");
    
    // Configure HTTP Strict Transport Security (HSTS)
    // The default HSTS max-age value is 30 days. You may want to change this for production scenarios.
    // For more information, see https://aka.ms/aspnetcore-hsts
    app.UseHsts();
}

/// <summary>
/// Enable HTTPS redirection.
/// This middleware redirects all HTTP requests to HTTPS to ensure secure communication.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Enable routing.
/// This middleware enables the routing functionality required for the application to match URLs to handlers.
/// </summary>
app.UseRouting();

/// <summary>
/// Enable authorization.
/// This middleware enforces authorization policies. Must be called after routing but before endpoint mapping.
/// </summary>
app.UseAuthorization();

/// <summary>
/// Map static assets.
/// This enables serving of static assets (CSS, JavaScript, images, etc.) from the wwwroot directory.
/// </summary>
app.MapStaticAssets();

/// <summary>
/// Map Razor Pages endpoints.
/// This registers all Razor Pages found in the Pages directory as endpoints.
/// The WithStaticAssets() extension enables static asset support for the pages.
/// </summary>
app.MapRazorPages()
   .WithStaticAssets();

/// <summary>
/// Start the application and begin listening for HTTP requests.
/// This call is blocking and will continue until the application is shut down.
/// </summary>
app.Run();
