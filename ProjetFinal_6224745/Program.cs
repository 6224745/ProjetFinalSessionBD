using Microsoft.EntityFrameworkCore;
using ProjetFinal_6224745.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BdGymnastiqueContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("BD_Gymnastique")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Agres}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
