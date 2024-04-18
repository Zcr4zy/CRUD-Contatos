using CRUD_Contatos.Data;
using CRUD_Contatos.Models;
using CRUD_Contatos.Repositorios;
using CRUD_Contatos.Repositorios.Contato;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Contatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Contexto>(o => o.UseInMemoryDatabase("BancoEmMemória"));
            builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

            var app = builder.Build();



            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var contexto = services.GetRequiredService<Contexto>();

                // Instância a classe PopularDados e chama o método PopularContatos
                var popularDados = new PopularDados(contexto);
                popularDados.PopularContatos();
            }

           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
