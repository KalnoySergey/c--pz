using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Data;

namespace LR1_TestCode1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Регистрация контроллеров и представлений
            builder.Services.AddControllersWithViews();

            // Подключение Entity Framework Core к Azure SQL
            var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING") 
                ?? builder.Configuration["AZURE_SQL_CONNECTIONSTRING"];

            builder.Services.AddDbContext<MyDatabaseContext>(options =>
                options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Конфигурация конвейера обработки запросов (Pipeline)
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Todos}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
