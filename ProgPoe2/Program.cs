var builder = WebApplication.CreateBuilder(args); // Create a web application builder

builder.Services.AddControllersWithViews(); // Add services for controllers with views

var app = builder.Build(); // Build the web application

if (!app.Environment.IsDevelopment()) // Check if the environment is not development
{
    app.UseExceptionHandler("/Home/Error"); // Use custom error handler for production
    app.UseHsts(); // Use HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Enable serving of static files

app.UseRouting(); // Enable routing

app.UseAuthorization(); // Enable authorization

app.MapControllerRoute( // Configure the default route for controllers
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route pattern

app.Run(); // Run the application
