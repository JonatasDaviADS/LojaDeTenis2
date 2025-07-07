using LojaDeTenis.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LojaDeTenisContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LojaDeTenisContext") ?? throw new InvalidOperationException("Connection string 'LojaDeTenisContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/Index";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<LojaDeTenisContext>();

        if (!context.Usuario.Any())
        {
            context.Usuario.Add(new LojaDeTenis.Models.Usuario
            {
                Nome = "Admin",
                Email = "admin@admin.com",
                SenhaHash = "123",
                IsAdmin = true
            });

            context.SaveChanges();
            Console.WriteLine("Usuário administrador criado com sucesso.");
        }
    }
}



app.Run();
