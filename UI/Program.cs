using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using HieuThuoc.Data.Repositories;
using HieuThuoc.Services.Implementations;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Forms;
using HieuThuoc.UI.Presenters;
using System.Configuration;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI
{
    static class Program
    {
        // Public service provider để các Form có thể resolve instance từ DI nếu cần
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Read connection string from app.config
            var connString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connString))
            {
                MessageBox.Show("Connection string not found. Please set DefaultConnection in app.config", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var services = new ServiceCollection();

            // Register Repo and Service
            services.AddSingleton<IAccountRepository>(sp => new AccountRepository(connString));
            services.AddSingleton<IRoleRepository>(sp => new RoleRepository(connString));
            services.AddSingleton<IMedicineRepository>(sp => new MedicineRepository(connString));
            services.AddSingleton<IPackagingRepository>(sp => new PackagingRepository(connString));
            services.AddSingleton<ISupplierRepository>(sp => new SupplierRepository(connString));

            // Services
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IReportService>(sp => new ReportService(connString));
            services.AddSingleton<IBatchService>(sp => new BatchService(connString));
            services.AddSingleton<IUserService>(sp => new UserService(connString, sp.GetRequiredService<IRoleRepository>()));
            services.AddSingleton<IUserManagementService, UserManagementService>();
            services.AddSingleton<IMedicineService, MedicineService>();
            services.AddSingleton<IPackagingService, PackagingService>();
            services.AddSingleton<ISupplierService, SupplierService>();
            services.AddSingleton<ISaleService>(sp => new SaleService(connString));
            services.AddSingleton<IPurchaseService>(sp => new PurchaseService(connString));
            services.AddSingleton<ISaleLookupService>(sp => new SaleLookupService(connString));

            // Register Forms and wire presenter when creating form via factory
            services.AddTransient<FormLogin>(sp =>
            {
                // create FormLogin and its presenter, then return form
                var form = new FormLogin();
                var view = form as ILoginView;
                var auth = sp.GetRequiredService<IAuthService>();
                // new presenter will call view.SetPresenter(this)
                var presenter = new LoginPresenter(view, auth);
                return form;
            });

            // Register main menu form (no presenter needed here)
            services.AddTransient<FormMainMenu>(sp =>
            {
                var form = new FormMainMenu();
                return form;
            });

            // thêm Form vào DI
            services.AddTransient<FormCreateUser>(sp => new FormCreateUser());
            services.AddTransient<FormUserManagement>(sp => new FormUserManagement());
            services.AddTransient<FormMedicineManagement>(sp => new FormMedicineManagement());
            services.AddTransient<FormPackagingManagement>(sp => new FormPackagingManagement());
            services.AddTransient<FormSupplierManagement>(sp => new FormSupplierManagement());
            services.AddTransient<FormBatchManagement>(sp => new FormBatchManagement());

            // Build provider and store globally
            ServiceProvider = services.BuildServiceProvider();

            // Resolve main form from DI and run
            var mainForm = ServiceProvider.GetRequiredService<FormMainMenu>();
            Application.Run(mainForm);
        }
    }
}
