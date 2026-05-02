using EczaneOtomasyon.Bussines.Services;
using EczaneOtomasyon.Bussines.Services.Implementations;
using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain;
using EczaneOtomasyon.Domain.Interfaces;
using EczaneOtomasyon.Infrastructure;
using EczaneOtomasyon.Infrastructure.Repositories;
using EczaneOtomasyon.UI;
using EczaneOtomasyon.UI.Admin;
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
            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IReceteTurRepository, ReceteTurRepository>();
            services.AddScoped<IDoktorlarRepository, DoktorlarRepository>();
            services.AddScoped<IHastalarRepository, HastalarRepository>();
            services.AddScoped<IRecetelerRepository, RecetelerRepository>();
            services.AddScoped<IReceteDetayRepository, ReceteDetayRepository>();
            services.AddScoped<ISatislarRepository, SatislarRepository>();
            services.AddScoped<ISatisDetayRepository, SatisDetayRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceOfWork, ServiceOfWork>();

            services.AddScoped<IKullanicilarService, KullanicilarService>();
            services.AddScoped<IIlaclarService, IlaclarService>();
            services.AddScoped<IKategoriService, KategoriService>();
            services.AddScoped<IReceteTurService, ReceteTurService>();
            services.AddScoped<IDoktorlarService, DoktorlarService>();
            services.AddScoped<IHastalarService, HastalarService>();
            services.AddScoped<IRecetelerService, RecetelerService>();
            services.AddScoped<ISatislarService, SatislarService>();
            services.AddSingleton<EczaneOtomasyon.Bussines.Services.Interfaces.IAuthService, EczaneOtomasyon.Bussines.Services.Implementations.AuthService>();


            services.AddTransient<Frmlogin>();
            services.AddTransient<FrmIlacEkle>();
            services.AddTransient<UcIlacStok>();
            services.AddTransient<FrmHastaRecete>();
            services.AddTransient<UcHastaRecete>();
            services.AddTransient<UcSatisFatura>();
            services.AddTransient<UcDuzenlemeArayuz>();
            services.AddTransient<FrmAdminDashboard>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
