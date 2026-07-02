using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MTTApp.Pages;

/// <summary>
/// ErrorModel represents the page model for the application's error handling page.
/// This page is displayed when an unhandled exception occurs in the application.
/// 
/// The model is configured to:
/// - Disable response caching to prevent error pages from being cached
/// - Ignore anti-forgery token validation since errors can occur before token validation
/// - Display the request ID to help with debugging and support investigations
/// </summary>
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    /// <summary>
    /// Gets or sets the request ID associated with the error.
    /// This ID helps identify and track specific requests that resulted in errors.
    /// Used for logging, debugging, and providing users/support with traceable error information.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Gets a value indicating whether the RequestId should be displayed to the user.
    /// Returns true if the RequestId has a value (not null or empty), false otherwise.
    /// This is useful for conditionally showing the request ID in the UI.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    /// <summary>
    /// Handles GET requests to the error page.
    /// This method is called when the application redirects to the error page.
    /// 
    /// The method attempts to retrieve the request ID using the following priority:
    /// 1. Activity.Current?.Id - The current distributed trace activity ID (if available)
    /// 2. HttpContext.TraceIdentifier - The HTTP context's trace identifier
    /// 
    /// The Activity.Current?.Id is preferred because it provides better distributed tracing
    /// support across multiple services and systems.
    /// </summary>
    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}


