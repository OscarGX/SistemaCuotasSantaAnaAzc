using Business;
using Business.Infrastructure;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaCuotas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCuotas
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var mainForm = serviceProvider.GetRequiredService<Login>();
            Application.Run(mainForm);
            // Application.Run(new MainForm());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // services.AddDbContext<scazContext>(opt => opt.UseMySql("server=localhost;port=3306;user=root;password=1234;database=scaz", ServerVersion.Parse("8.0.16-mysql")));
            services.AddSingleton<Login>();
            // services.AddScoped<scazContext>();
            services.AddScoped<IAccountBusiness, AccountBusiness>();
        }
    }
}
