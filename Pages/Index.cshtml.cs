using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MTTApp.Pages;

/// <summary>
/// IndexModel represents the page model for the application's home/index page.
/// This is a Razor Pages page model that handles HTTP requests to the "/" route.
/// 
/// Razor Pages is a page-focused ASP.NET Core framework that makes it easier to build
/// web UI features with a clear separation of concerns. Each page has an associated
/// code-behind class (PageModel) that handles the page's logic.
/// </summary>
public class IndexModel : PageModel
{
    /// <summary>
    /// Handles GET requests to the index page.
    /// This method is called when a user navigates to the home page.
    /// 
    /// Currently, this handler doesn't perform any special logic.
    /// In a real application, you might:
    /// - Load data from a database
    /// - Fetch data from an API
    /// - Initialize page properties with dynamic content
    /// </summary>
    public void OnGet()
    {
        // Placeholder for future index page logic
    }
}
