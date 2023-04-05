using Emp_performance_appraisal.Data;
using Emp_performance_appraisal.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string? con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EmpContext>(builder => builder.UseSqlServer(con));
builder.Services.AddScoped<basicfn>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Home/Index";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.AccessDeniedPath = "/Home/Index";
});

builder.Services.AddAuthorization(options =>
{
    //setting policy for the HR
    options.AddPolicy("BelongsToHR", policy =>
    {
        policy.RequireClaim("Designation", "HR");
    });



    //setting privacy for the Manager
    options.AddPolicy("BelongsToManager", policy =>
    {
        policy.RequireClaim("Designation", "Manager");
    });


    

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
//app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
