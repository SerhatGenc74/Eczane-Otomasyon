using EczaneOtomasyon.Bussines.Services.Implementations;
using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain;
using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Infrastructure;
using EczaneOtomasyon.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            var loginForm = ServiceProvider.GetRequiredService<Frmlogin>();
            Application.Run(loginForm);
        }
        static void ConfigureServices()
        {
            var services = new ServiceCollection();


            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IKullanicilarRepository, KullanicilarRepository>();
            services.AddScoped<IIlaclarRepository, IlaclarRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IKullanicilarService, KullanicilarService>();
            services.AddScoped<IIlaclarService, IlaclarService>();


            services.AddTransient<Frmlogin>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
