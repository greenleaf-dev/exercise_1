using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MTTApp.Pages;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HiringDate { get; set; }
    public string Department { get; set; }
    public string JobTitle { get; set; }
}

public class PrivacyModel : PageModel
{
    public List<Employee> Employees { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "sampledata.json");
            if (System.IO.File.Exists(filePath))
            {
                var json = await System.IO.File.ReadAllTextAsync(filePath);
                Employees = JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
            }
        }
        catch
        {
            Employees = new List<Employee>();
        }
    }
}

