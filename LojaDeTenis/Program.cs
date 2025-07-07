using LojaDeTenis.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using LojaDeTenis.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Conexão com o banco de dados
builder.Services.AddDbContext<LojaDeTenisContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LojaDeTenisContext")
        ?? throw new InvalidOperationException("Connection string 'LojaDeTenisContext' not found.")));

// MVC
builder.Services.AddControllersWithViews();

// Autenticação via cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/Index";
    });

var app = builder.Build();

// Erro customizado em produção
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Ativa autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Roteamento padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Cria usuário admin na primeira execução
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
                SenhaHash = CriptografiaHelper.GerarHash("123"),
                IsAdmin = true
            });

            context.SaveChanges();
            Console.WriteLine("Usuário administrador criado com sucesso.");
        }
    }
}

app.Run();
